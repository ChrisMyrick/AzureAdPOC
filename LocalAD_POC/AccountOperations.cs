using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Configuration;
using LocalAD_POC.Models;

namespace LocalAD_POC
{
    public class AccountOperations
    {

        public HashSet<UserInfoFromAD> GetOUUsers(string OUName)
        {
            var users = new HashSet<UserInfoFromAD>();
            var directory = "LDAP://" + OUName;

            var directoryEntry = new DirectoryEntry(directory);
            var login = string.Empty;
            var email = string.Empty;
            var displayName = string.Empty;
            foreach (DirectoryEntry child in directoryEntry.Children)
            {
                if (child.SchemaClassName == "user")
                {
                    login = (child.Properties["SamAccountName"].Value != null) ?
                        child.Properties["SamAccountName"].Value.ToString() : string.Empty;

                    email = (child.Properties["mail"].Value != null) ?
                        child.Properties["mail"].Value.ToString() : string.Empty;

                    displayName = (child.Properties["displayName"].Value != null) ?
                        child.Properties["displayName"].Value.ToString() : string.Empty;

                    users.Add(new UserInfoFromAD(login, email, displayName));
                }
                else if (child.SchemaClassName == "group")
                {
                    users.UnionWith(GetADGroupUsers(child.Properties["SamAccountName"].Value.ToString()));
                }
            }
            return users;
        }

        public HashSet<UserInfoFromAD> GetADGroupUsers(string groupName)
        {
            var users = new HashSet<UserInfoFromAD>();
            string login = string.Empty;
            string email = string.Empty;
            string displayName = string.Empty;
            using (var principalContext = new PrincipalContext(ContextType.Domain))
            {
                using (var group = GroupPrincipal.FindByIdentity(principalContext, groupName))
                {
                    if (group != null)
                    {
                        var searchResults = group.GetMembers();
                        foreach (var principal in searchResults)
                        {
                            if (principal.StructuralObjectClass == "user")
                            {
                                login = principal.SamAccountName;
                                email = ((UserPrincipal)principal).EmailAddress;
                                displayName = principal.DisplayName;

                                users.Add(new UserInfoFromAD(login, email, displayName));
                            }
                            else if (principal.StructuralObjectClass == "group")
                            {
                                users.UnionWith(GetADGroupUsers(principal.SamAccountName));
                            }
                        }
                    }

                }
            }
            return users;

        }


        public UserInfoFromAD GetUserInfoFromAD(string login)
        {

            var email = string.Empty;
            var displayName = string.Empty;


            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection)
                {
                    Filter = "(samaccountname=" + login + ")",
                    PropertiesToLoad = { "mail", "displayName" },
                })
                {
                    var user = search.FindOne();
                    if (user == null) { return null; }
                    email = (user.Properties["mail"] != null && user.Properties["mail"].Count > 0) ? (string)user.Properties["mail"][0] : string.Empty;
                    displayName = (user.Properties["displayname"] != null) ? (string)user.Properties["displayname"][0] : string.Empty;
                }
            }

            return new UserInfoFromAD(login, email, displayName);

        }

        public List<ADSearchDTO> SearchAD(string searchTerm)
        {
            var searchArray = searchTerm.Split(' ');
            var filter = string.Empty;
            if (searchArray.Length > 1)
            {
                filter = "(&(|(&(objectCategory=group)(objectClass=group))(&(objectcategory=person)(objectclass=user)))(&(sn="
                                + searchArray[0] + "*)(givenName=" + searchArray[1] + "*)))";
            }
            else
            {
                filter = "(&(|(&(objectCategory=group)(objectClass=group))(&(objectcategory=person)(objectclass=user)))(samaccountname="
                                + searchTerm + "))";
            }
            var email = string.Empty;
            var displayName = string.Empty;
            var login = string.Empty;
            var objectcategory = string.Empty;
            var isGroup = false;

            List<ADSearchDTO> results = new List<ADSearchDTO>();

            SearchResultCollection searchResults;

            // DirectoryEntry entry = new DirectoryEntry(strLDAPPath, strLDAPUsername, strLDAPPassword)
            using (var connection = new DirectoryEntry())
            {
                using (var search = new DirectorySearcher(connection))
                {
                    //search.Filter = "(&(|(&(objectCategory=group)(objectClass=group))(&(objectcategory=person)(objectclass=user)))(|(sn="
                    //            + searchTerm + "*)(samaccountname=" + searchTerm + "*)))";
                    search.Filter = filter;

                    search.SizeLimit = 30;
                    searchResults = search.FindAll();

                    foreach (SearchResult r in searchResults)
                    {
                        email = (r.Properties["mail"] != null && r.Properties["mail"].Count > 0) ? (string)r.Properties["mail"][0] : string.Empty;
                        login = (r.Properties["samaccountname"] != null) ? (string)r.Properties["samaccountname"][0] : string.Empty;
                        displayName = (r.Properties["displayname"] != null) ? (string)r.Properties["displayname"][0] : string.Empty;
                        objectcategory = (r.Properties["objectcategory"] != null) ? (string)r.Properties["objectcategory"][0] : string.Empty;
                        isGroup = objectcategory.StartsWith("CN=Group");
                        results.Add(new ADSearchDTO
                        {
                            Login = login,
                            DisplayName = displayName,
                            Email = email,
                            isGroup = isGroup
                        });
                    }



                }
            }
            return results;
        }

        public bool UserHasADGroup(string login, string adGroupName)
        {
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);
            GroupPrincipal group = GroupPrincipal.FindByIdentity(principalContext, adGroupName);

            // If we can't find an AD gorup with this name, return false.
            if (group == null) { return false; }

            string domain = GetDomainForOU(group.DistinguishedName).ToLower();


            DirectoryEntry rootEntry = new DirectoryEntry("LDAP://" + domain);

            DirectorySearcher srch = new DirectorySearcher(rootEntry);
            srch.SearchScope = SearchScope.Subtree;


            srch.Filter = "(&(objectcategory=user)(sAMAccountName=" + login + ")(memberof=" + group.DistinguishedName + "))";

            SearchResultCollection res = srch.FindAll();

            if (res == null || res.Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private string GetDomainForOU(string nameOU)
        {

            string strDomain = null;
            string[] OUArr = nameOU.Split(',');

            int DCcount = 0;

            for (int i = 0; i < OUArr.Length; i++)
            {
                string[] Arrsubstr = OUArr[i].Split('=');
                if (Arrsubstr[0] == "DC")
                {
                    ++DCcount;

                    if (i != OUArr.Length - 1)
                        strDomain += Arrsubstr[1] + ".";
                    else
                        strDomain += Arrsubstr[1];

                }

            }

            //string dom = String.Format("{0}{1}", strDomain.Split('.')[0].ToUpper(), @"\");  
            //// We need to get rid of extra \
            //dom = dom.Substring(0, dom.Length-1);
            return strDomain.Split('.')[0].ToLower();
        }

        public List<string> GetUserGroups(string domainDN, string sAMAccountName)
        {
            List<string> lGroups = new List<string>();

            //Create the DirectoryEntry object to bind the distingusihedName of your domain 
            using (DirectoryEntry rootDE = new DirectoryEntry("LDAP://" + domainDN))
            {
                //Create a DirectorySearcher for performing a search on abiove created DirectoryEntry 
                using (DirectorySearcher dSearcher = new DirectorySearcher(rootDE))
                {
                    //Create the sAMAccountName as filter 
                    dSearcher.Filter = "(&(sAMAccountName=" + sAMAccountName + ")(objectClass=User)(objectCategory=Person))";
                    dSearcher.PropertiesToLoad.Add("memberOf");
                    dSearcher.ClientTimeout.Add(new TimeSpan(0, 20, 0));
                    dSearcher.ServerTimeLimit.Add(new TimeSpan(0, 20, 0));

                    //Search the user in AD 
                    SearchResult sResult = dSearcher.FindOne();
                    if (sResult == null)
                    {
                        throw new ApplicationException("No user with username " + sAMAccountName + " could be found in the domain");
                    }
                    else
                    {
                        //Once we get the userm let us get all the memberOF attibute's value 
                        foreach (var grp in sResult.Properties["memberOf"])
                        {
                            string sGrpName = Convert.ToString(grp).Remove(0, 3);
                            //Bind to this group 
                            DirectoryEntry deTempForSID = new DirectoryEntry("LDAP://" + grp.ToString().Replace("/", "\\/"));
                            try
                            {
                                deTempForSID.RefreshCache();

                                //Get the objectSID which is Byte array 
                                byte[] objectSid = (byte[])deTempForSID.Properties["objectSid"].Value;

                                //Pass this Byte array to Security.Principal.SecurityIdentifier to convert this 
                                //byte array to SDDL format 
                                System.Security.Principal.SecurityIdentifier SID = new System.Security.Principal.SecurityIdentifier(objectSid, 0);

                                if (sGrpName.Contains(",CN"))
                                {
                                    sGrpName = sGrpName.Remove(sGrpName.IndexOf(",CN"));
                                }
                                else if (sGrpName.Contains(",OU"))
                                {
                                    sGrpName = sGrpName.Remove(sGrpName.IndexOf(",OU"));
                                }

                                //Perform a recursive search on these groups. 
                                RecursivelyGetGroups(dSearcher, lGroups, sGrpName, SID.ToString());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error while binding to path : " + grp.ToString());
                                Console.WriteLine(ex.Message.ToString());
                            }
                        }
                    }
                }
            }


            return lGroups;
        }

        public void RecursivelyGetGroups(DirectorySearcher dSearcher, List<string> lGroups, string sGrpName, string SID)
        {
            //Check if the group has already not found 
            if (!lGroups.Contains(sGrpName))
            {
                lGroups.Add(sGrpName + " : " + SID);

                //Now perform the search based on this group 
                dSearcher.Filter = "(&(objectClass=grp)(CN=" + sGrpName + "))".Replace("\\", "\\\\");
                dSearcher.ClientTimeout.Add(new TimeSpan(0, 2, 0));
                dSearcher.ServerTimeLimit.Add(new TimeSpan(0, 2, 0));

                //Search this group 
                SearchResult GroupSearchResult = dSearcher.FindOne();
                if ((GroupSearchResult != null))
                {
                    foreach (var grp in GroupSearchResult.Properties["memberOf"])
                    {

                        string ParentGroupName = Convert.ToString(grp).Remove(0, 3);

                        //Bind to this group 
                        DirectoryEntry deTempForSID = new DirectoryEntry("LDAP://" + grp.ToString().Replace("/", "\\/"));
                        try
                        {
                            //Get the objectSID which is Byte array 
                            byte[] objectSid = (byte[])deTempForSID.Properties["objectSid"].Value;

                            //Pass this Byte array to Security.Principal.SecurityIdentifier to convert this 
                            //byte array to SDDL format 
                            System.Security.Principal.SecurityIdentifier ParentSID = new System.Security.Principal.SecurityIdentifier(objectSid, 0);

                            if (ParentGroupName.Contains(",CN"))
                            {
                                ParentGroupName = ParentGroupName.Remove(ParentGroupName.IndexOf(",CN"));
                            }
                            else if (ParentGroupName.Contains(",OU"))
                            {
                                ParentGroupName = ParentGroupName.Remove(ParentGroupName.IndexOf(",OU"));
                            }
                            RecursivelyGetGroups(dSearcher, lGroups, ParentGroupName, ParentSID.ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error while binding to path : " + grp.ToString());
                            Console.WriteLine(ex.Message.ToString());
                        }
                    }
                }
            }
        }


    }
}

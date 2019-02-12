using AuthPOC.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthPOC.Model
{
    public class User
    {
        public string Name { get; set; }
        public List<PermissionGroup> PermissionGroups { get; set; }
        public List<PermissionAttrib> PermissionAttribs { get; set; }

        public User()
        {
            PermissionGroups = new List<PermissionGroup>();
            PermissionAttribs = new List<PermissionAttrib>();
        }

        public void AssignPermission(List<ADAssignable> adAssignables, PermissionManager permissionManager)
        {
            PermissionGroups = permissionManager.getPermissionGroups(adAssignables);
            PermissionAttribs = permissionManager.getPermissionAttributions(adAssignables);
        }

    }
}

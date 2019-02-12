using AuthPOC.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Security.Principal;
using AuthPOC.Code;
using AuthPOC.Model;

namespace AuthPOC
{
    public partial class Form1 : Form
    {
        PermissionDbContext _db = new PermissionDbContext();
        User _user = new User();
        
        public Form1()
        {
            InitializeComponent();
            this.Disposed += (o, e) => _db.Dispose();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var identity = WindowsIdentity.GetCurrent();
            _user.Name = identity.Name;
            lblUserName.Text = "Current User: " + _user.Name;

            var permissionMgr = new PermissionManager(_db);
            foreach (var group in permissionMgr.AppPermissionGroups)
            {
                var permissionNode = new TreeNode(group.Name);

                foreach (var attib in group.PermissionAttribs)
                {
                    permissionNode.Nodes.Add(new TreeNode(attib.Name));
                }
                treePermissions.Nodes.Add(permissionNode);
            }

            var sb = new StringBuilder();
            permissionMgr.AssignableAttribs.ForEach(a =>
            {
                sb.Append(a.Name);
                sb.AppendLine();
            });
            txtAttribs.Text = sb.ToString();

            sb = new StringBuilder();
            permissionMgr.UnAssignableAttribs.ForEach(a =>
            {
                sb.Append(a.Name);
                sb.AppendLine();
            });
            txtHiddentAttrib.Text = sb.ToString();

            chklstADGroup.Items.AddRange(permissionMgr.ADAssignables.ToArray());

           

        }

       

        private void chklstADGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chklstADGroup_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => AssignPermissions()));
        }

        private void AssignPermissions()
        {
            // Show effective Attribs using Assignables
            var assignables = chklstADGroup.CheckedItems.Cast<ADAssignable>().ToList();
            var permissionMgr = new PermissionManager(_db);
            var effectiveAttribs = permissionMgr.GetEffectivePermissionAttrib(assignables);
            string attribs = effectiveAttribs.Select(a => a.Name).Aggregate("", (current, next) => current + Environment.NewLine + next);

            txtEffectiveAttribs.Text = attribs;

            _user.AssignPermission(assignables, permissionMgr);
            txtUserAssignedAttribs.Text = _user.PermissionAttribs.Select(a => a.Name)
                .Aggregate("", (acc, x) => acc + Environment.NewLine + x);
            txtUserAssignedGroups.Text = _user.PermissionGroups.Select(a => a.Name)
                .Aggregate("", (acc, x) => acc + Environment.NewLine + x);

        }


    }
}

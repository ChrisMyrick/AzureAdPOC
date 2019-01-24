using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalAD_POC
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            AccountOperations accountOp = new AccountOperations();
            var results = accountOp.SearchAD(txtSearchTerm.Text.Trim());
            var resultList = results.Select(r => r.DisplayName + ":" + r.Email).ToArray();
            txtResults.Text = (resultList.Length > 0) ? String.Join(Environment.NewLine, resultList) : "No results found";
        }

        private void btnGetUserFromGroup_Click(object sender, EventArgs e)
        {
            AccountOperations accountOp = new AccountOperations();
            var results = accountOp.GetADGroupUsers(txtADGroupName.Text.Trim());
            var resultList = results.Select(r => r.DisplayName + ":" + r.Email).ToArray();
            txtUsersInGroup.Text = (resultList.Length > 0) ? String.Join(Environment.NewLine, resultList) : "No results found";
        }

        private void btnGetUserGroups_Click(object sender, EventArgs e)
        {
            AccountOperations accountOp = new AccountOperations();
            var results = accountOp.GetUserGroups("svmic.com", txtUserLogin.Text.Trim());
            txtGroupsForUser.Text = (results.Count > 0) ? String.Join(Environment.NewLine, results) : "No results found";
        }
    }
}

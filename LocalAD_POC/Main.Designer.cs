namespace LocalAD_POC
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtADGroupName = new System.Windows.Forms.TextBox();
            this.btnGetUserFromGroup = new System.Windows.Forms.Button();
            this.txtUsersInGroup = new System.Windows.Forms.TextBox();
            this.txtUserLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGroupsForUser = new System.Windows.Forms.TextBox();
            this.btnGetUserGroups = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(49, 38);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(427, 20);
            this.txtSearchTerm.TabIndex = 0;
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Location = new System.Drawing.Point(538, 35);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(135, 23);
            this.btnSearchUser.TabIndex = 1;
            this.btnSearchUser.Text = "Search User";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(49, 64);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(681, 107);
            this.txtResults.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search by Login or LastName FirstName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "AD Group Name";
            // 
            // txtADGroupName
            // 
            this.txtADGroupName.Location = new System.Drawing.Point(55, 218);
            this.txtADGroupName.Name = "txtADGroupName";
            this.txtADGroupName.Size = new System.Drawing.Size(427, 20);
            this.txtADGroupName.TabIndex = 5;
            // 
            // btnGetUserFromGroup
            // 
            this.btnGetUserFromGroup.Location = new System.Drawing.Point(541, 215);
            this.btnGetUserFromGroup.Name = "btnGetUserFromGroup";
            this.btnGetUserFromGroup.Size = new System.Drawing.Size(135, 23);
            this.btnGetUserFromGroup.TabIndex = 6;
            this.btnGetUserFromGroup.Text = "Get Users in Group";
            this.btnGetUserFromGroup.UseVisualStyleBackColor = true;
            this.btnGetUserFromGroup.Click += new System.EventHandler(this.btnGetUserFromGroup_Click);
            // 
            // txtUsersInGroup
            // 
            this.txtUsersInGroup.Location = new System.Drawing.Point(52, 253);
            this.txtUsersInGroup.Multiline = true;
            this.txtUsersInGroup.Name = "txtUsersInGroup";
            this.txtUsersInGroup.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUsersInGroup.Size = new System.Drawing.Size(681, 107);
            this.txtUsersInGroup.TabIndex = 7;
            // 
            // txtUserLogin
            // 
            this.txtUserLogin.Location = new System.Drawing.Point(55, 416);
            this.txtUserLogin.Name = "txtUserLogin";
            this.txtUserLogin.Size = new System.Drawing.Size(427, 20);
            this.txtUserLogin.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "User Login";
            // 
            // txtGroupsForUser
            // 
            this.txtGroupsForUser.Location = new System.Drawing.Point(52, 442);
            this.txtGroupsForUser.Multiline = true;
            this.txtGroupsForUser.Name = "txtGroupsForUser";
            this.txtGroupsForUser.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGroupsForUser.Size = new System.Drawing.Size(681, 107);
            this.txtGroupsForUser.TabIndex = 11;
            // 
            // btnGetUserGroups
            // 
            this.btnGetUserGroups.Location = new System.Drawing.Point(538, 413);
            this.btnGetUserGroups.Name = "btnGetUserGroups";
            this.btnGetUserGroups.Size = new System.Drawing.Size(135, 23);
            this.btnGetUserGroups.TabIndex = 10;
            this.btnGetUserGroups.Text = "Get Groups for User";
            this.btnGetUserGroups.UseVisualStyleBackColor = true;
            this.btnGetUserGroups.Click += new System.EventHandler(this.btnGetUserGroups_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 599);
            this.Controls.Add(this.txtGroupsForUser);
            this.Controls.Add(this.btnGetUserGroups);
            this.Controls.Add(this.txtUserLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsersInGroup);
            this.Controls.Add(this.btnGetUserFromGroup);
            this.Controls.Add(this.txtADGroupName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnSearchUser);
            this.Controls.Add(this.txtSearchTerm);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtADGroupName;
        private System.Windows.Forms.Button btnGetUserFromGroup;
        private System.Windows.Forms.TextBox txtUsersInGroup;
        private System.Windows.Forms.TextBox txtUserLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGroupsForUser;
        private System.Windows.Forms.Button btnGetUserGroups;
    }
}
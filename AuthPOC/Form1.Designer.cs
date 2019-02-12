namespace AuthPOC
{
    partial class Form1
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
            this.treePermissions = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAttribs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chklstADGroup = new System.Windows.Forms.CheckedListBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEffectiveAttribs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHiddentAttrib = new System.Windows.Forms.TextBox();
            this.txtUserAssignedGroups = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserAssignedAttribs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treePermissions
            // 
            this.treePermissions.Location = new System.Drawing.Point(16, 47);
            this.treePermissions.Margin = new System.Windows.Forms.Padding(4);
            this.treePermissions.Name = "treePermissions";
            this.treePermissions.Size = new System.Drawing.Size(212, 222);
            this.treePermissions.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Permission Groups\r\nWith Attribs Assignments\r\n";
            // 
            // txtAttribs
            // 
            this.txtAttribs.Location = new System.Drawing.Point(13, 321);
            this.txtAttribs.Margin = new System.Windows.Forms.Padding(4);
            this.txtAttribs.Multiline = true;
            this.txtAttribs.Name = "txtAttribs";
            this.txtAttribs.Size = new System.Drawing.Size(212, 169);
            this.txtAttribs.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 283);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "Separately Assignable\r\nAttributes\r\n";
            // 
            // chklstADGroup
            // 
            this.chklstADGroup.FormattingEnabled = true;
            this.chklstADGroup.Location = new System.Drawing.Point(276, 76);
            this.chklstADGroup.Margin = new System.Windows.Forms.Padding(4);
            this.chklstADGroup.Name = "chklstADGroup";
            this.chklstADGroup.Size = new System.Drawing.Size(169, 276);
            this.chklstADGroup.TabIndex = 5;
            this.chklstADGroup.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstADGroup_ItemCheck);
            this.chklstADGroup.SelectedIndexChanged += new System.EventHandler(this.chklstADGroup_SelectedIndexChanged);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(522, 26);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(89, 17);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "Current User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 34);
            this.label4.TabIndex = 8;
            this.label4.Text = "Add current user to the \r\nfollowing in AD\r\n";
            // 
            // txtEffectiveAttribs
            // 
            this.txtEffectiveAttribs.Location = new System.Drawing.Point(525, 458);
            this.txtEffectiveAttribs.Multiline = true;
            this.txtEffectiveAttribs.Name = "txtEffectiveAttribs";
            this.txtEffectiveAttribs.Size = new System.Drawing.Size(170, 180);
            this.txtEffectiveAttribs.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(522, 438);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Effective Permission Attribs\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 507);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 34);
            this.label6.TabIndex = 11;
            this.label6.Text = "Attributes not to be\r\nIncluded in AD\r\n";
            // 
            // txtHiddentAttrib
            // 
            this.txtHiddentAttrib.Location = new System.Drawing.Point(13, 556);
            this.txtHiddentAttrib.Margin = new System.Windows.Forms.Padding(4);
            this.txtHiddentAttrib.Multiline = true;
            this.txtHiddentAttrib.Name = "txtHiddentAttrib";
            this.txtHiddentAttrib.Size = new System.Drawing.Size(212, 169);
            this.txtHiddentAttrib.TabIndex = 12;
            // 
            // txtUserAssignedGroups
            // 
            this.txtUserAssignedGroups.Location = new System.Drawing.Point(525, 77);
            this.txtUserAssignedGroups.Multiline = true;
            this.txtUserAssignedGroups.Name = "txtUserAssignedGroups";
            this.txtUserAssignedGroups.Size = new System.Drawing.Size(170, 152);
            this.txtUserAssignedGroups.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Assigned Groups";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(522, 241);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Assigned Attribs";
            // 
            // txtUserAssignedAttribs
            // 
            this.txtUserAssignedAttribs.Location = new System.Drawing.Point(525, 261);
            this.txtUserAssignedAttribs.Multiline = true;
            this.txtUserAssignedAttribs.Name = "txtUserAssignedAttribs";
            this.txtUserAssignedAttribs.Size = new System.Drawing.Size(170, 152);
            this.txtUserAssignedAttribs.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 772);
            this.Controls.Add(this.txtUserAssignedAttribs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserAssignedGroups);
            this.Controls.Add(this.txtHiddentAttrib);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEffectiveAttribs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.chklstADGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAttribs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treePermissions);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treePermissions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAttribs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chklstADGroup;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEffectiveAttribs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHiddentAttrib;
        private System.Windows.Forms.TextBox txtUserAssignedGroups;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUserAssignedAttribs;
    }
}


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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // treePermissions
            // 
            this.treePermissions.Location = new System.Drawing.Point(18, 59);
            this.treePermissions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treePermissions.Name = "treePermissions";
            this.treePermissions.Size = new System.Drawing.Size(238, 276);
            this.treePermissions.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Permission Groups\r\nWith Attribs Assignments\r\n";
            // 
            // txtAttribs
            // 
            this.txtAttribs.Location = new System.Drawing.Point(15, 401);
            this.txtAttribs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAttribs.Multiline = true;
            this.txtAttribs.Name = "txtAttribs";
            this.txtAttribs.Size = new System.Drawing.Size(238, 210);
            this.txtAttribs.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 354);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "Separately Assignable\r\nAttributes\r\n";
            // 
            // chklstADGroup
            // 
            this.chklstADGroup.FormattingEnabled = true;
            this.chklstADGroup.Location = new System.Drawing.Point(321, 137);
            this.chklstADGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chklstADGroup.Name = "chklstADGroup";
            this.chklstADGroup.Size = new System.Drawing.Size(190, 340);
            this.chklstADGroup.TabIndex = 5;
            this.chklstADGroup.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstADGroup_ItemCheck);
            this.chklstADGroup.SelectedIndexChanged += new System.EventHandler(this.chklstADGroup_SelectedIndexChanged);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(587, 32);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(100, 20);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "Current User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Admin UI";
            // 
            // txtEffectiveAttribs
            // 
            this.txtEffectiveAttribs.Location = new System.Drawing.Point(591, 572);
            this.txtEffectiveAttribs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEffectiveAttribs.Multiline = true;
            this.txtEffectiveAttribs.Name = "txtEffectiveAttribs";
            this.txtEffectiveAttribs.Size = new System.Drawing.Size(191, 224);
            this.txtEffectiveAttribs.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(587, 548);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Effective Permission Attribs\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 634);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 40);
            this.label6.TabIndex = 11;
            this.label6.Text = "Attributes not to be\r\nIncluded in AD\r\n";
            // 
            // txtHiddentAttrib
            // 
            this.txtHiddentAttrib.Location = new System.Drawing.Point(15, 681);
            this.txtHiddentAttrib.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHiddentAttrib.Multiline = true;
            this.txtHiddentAttrib.Name = "txtHiddentAttrib";
            this.txtHiddentAttrib.Size = new System.Drawing.Size(238, 210);
            this.txtHiddentAttrib.TabIndex = 12;
            // 
            // txtUserAssignedGroups
            // 
            this.txtUserAssignedGroups.Location = new System.Drawing.Point(591, 96);
            this.txtUserAssignedGroups.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserAssignedGroups.Multiline = true;
            this.txtUserAssignedGroups.Name = "txtUserAssignedGroups";
            this.txtUserAssignedGroups.Size = new System.Drawing.Size(191, 189);
            this.txtUserAssignedGroups.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Assigned Groups";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(587, 301);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Assigned Attribs";
            // 
            // txtUserAssignedAttribs
            // 
            this.txtUserAssignedAttribs.Location = new System.Drawing.Point(591, 326);
            this.txtUserAssignedAttribs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserAssignedAttribs.Multiline = true;
            this.txtUserAssignedAttribs.Name = "txtUserAssignedAttribs";
            this.txtUserAssignedAttribs.Size = new System.Drawing.Size(191, 189);
            this.txtUserAssignedAttribs.TabIndex = 16;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(321, 83);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 28);
            this.comboBox1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 965);
            this.Controls.Add(this.comboBox1);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.ComboBox comboBox1;
    }
}


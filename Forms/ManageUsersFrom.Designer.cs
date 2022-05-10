
namespace Administration.Forms
{
    partial class ManageUsersFrom
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
            this.gv_UsersList = new System.Windows.Forms.DataGridView();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.btn_RemoveUser = new System.Windows.Forms.Button();
            this.btn_RemoveUserFromRole = new System.Windows.Forms.Button();
            this.btn_AddUserToRole = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gv_UsersList)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_UsersList
            // 
            this.gv_UsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_UsersList.Location = new System.Drawing.Point(57, 61);
            this.gv_UsersList.Name = "gv_UsersList";
            this.gv_UsersList.RowHeadersWidth = 51;
            this.gv_UsersList.RowTemplate.Height = 29;
            this.gv_UsersList.Size = new System.Drawing.Size(456, 319);
            this.gv_UsersList.TabIndex = 0;
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.Location = new System.Drawing.Point(572, 61);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(199, 29);
            this.btn_AddUser.TabIndex = 1;
            this.btn_AddUser.Text = "Add User";
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // btn_RemoveUser
            // 
            this.btn_RemoveUser.Location = new System.Drawing.Point(572, 160);
            this.btn_RemoveUser.Name = "btn_RemoveUser";
            this.btn_RemoveUser.Size = new System.Drawing.Size(199, 29);
            this.btn_RemoveUser.TabIndex = 2;
            this.btn_RemoveUser.Text = "Remove User";
            this.btn_RemoveUser.UseVisualStyleBackColor = true;
            this.btn_RemoveUser.Click += new System.EventHandler(this.btn_RemoveUser_Click);
            // 
            // btn_RemoveUserFromRole
            // 
            this.btn_RemoveUserFromRole.Location = new System.Drawing.Point(572, 351);
            this.btn_RemoveUserFromRole.Name = "btn_RemoveUserFromRole";
            this.btn_RemoveUserFromRole.Size = new System.Drawing.Size(199, 29);
            this.btn_RemoveUserFromRole.TabIndex = 3;
            this.btn_RemoveUserFromRole.Text = "Remove User from Role";
            this.btn_RemoveUserFromRole.UseVisualStyleBackColor = true;
            this.btn_RemoveUserFromRole.Click += new System.EventHandler(this.btn_RemoveUserFromRole_Click);
            // 
            // btn_AddUserToRole
            // 
            this.btn_AddUserToRole.Location = new System.Drawing.Point(572, 260);
            this.btn_AddUserToRole.Name = "btn_AddUserToRole";
            this.btn_AddUserToRole.Size = new System.Drawing.Size(199, 29);
            this.btn_AddUserToRole.TabIndex = 4;
            this.btn_AddUserToRole.Text = "Add User to Role";
            this.btn_AddUserToRole.UseVisualStyleBackColor = true;
            this.btn_AddUserToRole.Click += new System.EventHandler(this.btn_AddUserToRole_Click);
            // 
            // ManageUsersFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_AddUserToRole);
            this.Controls.Add(this.btn_RemoveUserFromRole);
            this.Controls.Add(this.btn_RemoveUser);
            this.Controls.Add(this.btn_AddUser);
            this.Controls.Add(this.gv_UsersList);
            this.Name = "ManageUsersFrom";
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.ManageUsersFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_UsersList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_UsersList;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.Button btn_RemoveUser;
        private System.Windows.Forms.Button btn_RemoveUserFromRole;
        private System.Windows.Forms.Button btn_AddUserToRole;
    }
}
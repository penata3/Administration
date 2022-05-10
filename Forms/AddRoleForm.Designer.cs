
namespace Administration.Forms
{
    partial class AddRoleForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_RoleName = new System.Windows.Forms.TextBox();
            this.btn_CreateRole = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Role Name:";
            // 
            // tb_RoleName
            // 
            this.tb_RoleName.Location = new System.Drawing.Point(356, 137);
            this.tb_RoleName.Name = "tb_RoleName";
            this.tb_RoleName.Size = new System.Drawing.Size(160, 27);
            this.tb_RoleName.TabIndex = 1;
            // 
            // btn_CreateRole
            // 
            this.btn_CreateRole.Location = new System.Drawing.Point(422, 216);
            this.btn_CreateRole.Name = "btn_CreateRole";
            this.btn_CreateRole.Size = new System.Drawing.Size(94, 29);
            this.btn_CreateRole.TabIndex = 2;
            this.btn_CreateRole.Text = "Add Role";
            this.btn_CreateRole.UseVisualStyleBackColor = true;
            this.btn_CreateRole.Click += new System.EventHandler(this.btn_CreateRole_Click);
            // 
            // AddRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 379);
            this.Controls.Add(this.btn_CreateRole);
            this.Controls.Add(this.tb_RoleName);
            this.Controls.Add(this.label1);
            this.Name = "AddRoleForm";
            this.Text = "Add Role";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_RoleName;
        private System.Windows.Forms.Button btn_CreateRole;
    }
}
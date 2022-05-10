
namespace Administration.Forms
{
    partial class AddUserToRole
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
            this.lb_Username = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Roles = new System.Windows.Forms.CheckedListBox();
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lb1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Username
            // 
            this.lb_Username.AutoSize = true;
            this.lb_Username.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_Username.Location = new System.Drawing.Point(410, 60);
            this.lb_Username.Name = "lb_Username";
            this.lb_Username.Size = new System.Drawing.Size(109, 46);
            this.lb_Username.TabIndex = 0;
            this.lb_Username.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Roles To Add";
            // 
            // cb_Roles
            // 
            this.cb_Roles.FormattingEnabled = true;
            this.cb_Roles.Location = new System.Drawing.Point(372, 188);
            this.cb_Roles.Name = "cb_Roles";
            this.cb_Roles.Size = new System.Drawing.Size(188, 92);
            this.cb_Roles.TabIndex = 12;
            // 
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.Location = new System.Drawing.Point(133, 345);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Size = new System.Drawing.Size(147, 29);
            this.btn_SaveChanges.TabIndex = 13;
            this.btn_SaveChanges.Text = "Save Changes";
            this.btn_SaveChanges.UseVisualStyleBackColor = true;
            this.btn_SaveChanges.Click += new System.EventHandler(this.btn_SaveChanges_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(509, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 29);
            this.button2.TabIndex = 14;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(161, 80);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(75, 20);
            this.lb1.TabIndex = 15;
            this.lb1.Text = "Username";
            // 
            // AddUserToRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_SaveChanges);
            this.Controls.Add(this.cb_Roles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_Username);
            this.Name = "AddUserToRole";
            this.Text = "Add User To Role";
            this.Load += new System.EventHandler(this.AddUserToRole_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cb_Roles;
        private System.Windows.Forms.Button btn_SaveChanges;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lb1;
    }
}
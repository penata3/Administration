
namespace Administration.Forms
{
    using System;
    using System.Windows.Forms;
    using Administration.Services;

    public partial class ChangePasswordForm : Form
    {
        private readonly IUserManager userManager;

        public string UserId { get; set; }

        public ChangePasswordForm(IUserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var newPassword = tb_NewPassword.Text.Trim();
            var rePass = tb_RePassword.Text.Trim();


            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(rePass))
            {
                MessageBox.Show("Please fill all input boxes");
            }
            else if (newPassword.Length < 5)
            {
                MessageBox.Show("Password is too short");
            }

            else if (newPassword != rePass)
            {
                MessageBox.Show("Passwords don't match!");
            }
            else
            {

                await this.userManager.ChangePasswordAsync(UserId, newPassword);
                MessageBox.Show("Successfuly changed password");
                Close();
            }

        }
    }
}

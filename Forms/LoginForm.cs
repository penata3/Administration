namespace Administration
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Administration.Data.Models;
    using Administration.Infrastructure;
    using Administration.Services;

    public partial class LoginForm : Form
    {
        private readonly IUserManager userManager;
        private readonly IFormFactory formFactory;

        public LoginForm(IUserManager userManager, IFormFactory formFactory)
        {
            this.userManager = userManager;
            this.formFactory = formFactory;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = tb_Username.Text.Trim();
            var password = tb_Password.Text.Trim();

            var user = this.userManager.Login(username, password);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all the input boxes");
            }
            else if (user == null)
            {
                MessageBox.Show("Invalid username or password");
            }
            else
            {
                var mainWindowDi = this.formFactory.CreateMainWindow(user, this);
                mainWindowDi.Show();
                Hide();
            }
        }

    }
}

namespace Administration
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Administration.Forms;
    using Administration.Services;

    public partial class CreateUserForm : Form
    {
        private readonly IUserManager userManager;
        private readonly IRoleManager roleManager;
        private readonly ManageUsersFrom manageUsersFrom;


        public CreateUserForm(IUserManager userManager, IRoleManager roleManager, ManageUsersFrom manageUsersFrom)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.manageUsersFrom = manageUsersFrom;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var username = tb_Username.Text.Trim();
            var password = tb_Password.Text.Trim();
            var rePass = tb_RePass.Text.Trim();
            var roles = new List<string>();

            foreach (var role in cb_Roles.CheckedItems)
            {
                roles.Add(role.ToString());
            }

            if (username.Length < 5)
            {
                MessageBox.Show("Username too short");
            }
            else if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(rePass))
            {
                MessageBox.Show("Please fill all input text boxes");
            }

            else if (password.Length < 5)
            {
                MessageBox.Show("Password is too short");
            }

            else if (password != rePass)
            {
                MessageBox.Show("Passwords don't match!");
            }
            else if (this.userManager.ChekIfNameExists(username))
            {
                MessageBox.Show("User with the given username already exist!");
            }

            else
            {
                await this.userManager.CreateUserAsync(username, password, roles);
                MessageBox.Show("Successfully added user");
                this.manageUsersFrom.PopulateGrid();
                this.Close();
            }
        }


        private async void CreateUserForm_Load(object sender, EventArgs e)
        {
            var roles = await this.roleManager.GetAllRolesAsync();
            cb_Roles.CheckOnClick = true;

            foreach (var role in roles)
            {
                cb_Roles.Items.Add(role.Name);
            }
        }
    }
}

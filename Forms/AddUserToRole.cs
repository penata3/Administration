namespace Administration.Forms
{
    using System.Windows.Forms;
    using Administration.Data.Models;
    using Administration.Services;
    using System;

    public partial class AddUserToRole : Form
    {
        private readonly User user;
        private readonly IRoleManager roleManager;

        public AddUserToRole(User user, IRoleManager roleManager)
        {
            InitializeComponent();
            this.user = user;
            this.roleManager = roleManager;

        }

        private async void AddUserToRole_Load(object sender, EventArgs e)
        {
            lb_Username.Text = this.user.Username;

            var roles = this.roleManager.GetRolesUserNotIn(user.Id);
            cb_Roles.CheckOnClick = true;

            foreach (var role in roles)
            {
                cb_Roles.Items.Add(role);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_SaveChanges_Click_1(object sender, EventArgs e)
        {
            foreach (var role in cb_Roles.CheckedItems)
            {
                this.roleManager.AddUserToRole(user.Id, role.ToString());
            }
            Close();
        }
    }
}

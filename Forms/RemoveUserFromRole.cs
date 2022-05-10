namespace Administration.Forms
{
    using System.Windows.Forms;
    using Administration.Data.Models;
    using Administration.Services;
    public partial class RemoveUserFromRole : Form
    {
        private readonly User user;
        private readonly IRoleManager roleManager;

        public RemoveUserFromRole(User user, IRoleManager roleManager)
        {
            InitializeComponent();
            this.user = user;
            this.roleManager = roleManager;
        }

        private void RemoveUserFromRole_Load(object sender, System.EventArgs e)
        {
            lb_Username.Text = this.user.Username;

            var roles = this.roleManager.GetAllRolesForUser(user.Id);

            cb_Roles.CheckOnClick = true;

            foreach (var role in roles)
            {
                cb_Roles.Items.Add(role);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            foreach (var roleToRemove in cb_Roles.CheckedItems)
            {
                this.roleManager.RemoveUserFromRole(user.Id, roleToRemove.ToString());
            }
            Close();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}

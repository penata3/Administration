namespace Administration.Forms
{
    using System.Windows.Forms;
    using Administration.Services;

    public partial class AddRoleForm : Form
    {
        private readonly IRoleManager roleManager;

        public AddRoleForm(IRoleManager roleManager)
        {
            InitializeComponent();
            this.roleManager = roleManager;
        }

        private async void btn_CreateRole_Click(object sender, System.EventArgs e)
        {
            var roleName = tb_RoleName.Text.Trim();
            var roleExists = this.roleManager.RoleExists(roleName);

            if (roleExists)
            {
                MessageBox.Show("This role is already asigned!");
            }
            else 
            {
                await this.roleManager.CreateRoleAsync(roleName);
                MessageBox.Show($"Successfully added role {roleName}");
                Close();
            }
        }
    }
}

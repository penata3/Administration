namespace Administration
{
    using System;
    using System.Windows.Forms;
    using Administration.Data.Models;
    using Administration.Forms;
    using Administration.Infrastructure;
    using Administration.Services;

    public partial class MainWindow : Form
    {
        private readonly User user;
        private readonly LoginForm loginForm;
        private readonly IRoleManager roleManager;
        private readonly IFormFactory formFactory;

        public MainWindow(User user, LoginForm loginForm, IRoleManager roleManager, IFormFactory formFactory)
        {
            this.user = user;
            this.loginForm = loginForm;
            this.roleManager = roleManager;
            this.formFactory = formFactory;
            InitializeComponent();
        }


        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen(nameof(ManageUsersFrom)))
            {
                var manageUsersForm =this.formFactory.CreateManageUsersForm();
                manageUsersForm.MdiParent = this;
                manageUsersForm.Show();
            }

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Close();
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            var isUserAdministrator = this.roleManager.IsUserInRole(user.Username, "Administrator");
            statusLabel.Text = $"Logged in as: {this.user.Username}";

            if (!isUserAdministrator)
            {
                manageUsersToolStripMenuItem.Visible = false;
                rolesToolStripMenuItem.Visible = false;
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen(nameof(ChangePasswordForm)))
            {
                var changePasswordForm = this.formFactory.CreateChangePasswordForm();
                changePasswordForm.MdiParent = this;
                changePasswordForm.UserId = this.user.Id;
                changePasswordForm.Show();
            }
        }

        private void addRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen(nameof(AddRoleForm)))
            {
                var addRoleForm = this.formFactory.CreateAddRoleForm();
                addRoleForm.MdiParent = this;
                addRoleForm.Show();
            }
        }
    }
}

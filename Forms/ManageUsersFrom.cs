namespace Administration.Forms
{
    using System.Windows.Forms;
    using Administration.Infrastructure;
    using Administration.Services;
    using System;

    public partial class ManageUsersFrom : Form
    {
        private readonly IUserManager userManger;
        private readonly IRoleManager roleManager;
        private readonly IFormFactory formFactory;

        public ManageUsersFrom(IUserManager userManger, IRoleManager roleManager, IFormFactory formFactory)
        {
            InitializeComponent();
            this.userManger = userManger;
            this.roleManager = roleManager;
            this.formFactory = formFactory;
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen(nameof(CreateUserForm)))
            {
                var createUserForm = this.formFactory.CreateUserForm(this);
                createUserForm.Show();
            }
        }

        private async void ManageUsersFrom_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private async void btn_RemoveUser_Click(object sender, EventArgs e)
        {
            try
            {
                var userId = gv_UsersList.SelectedRows[0].Cells["Id"].Value.ToString();
                await this.userManger.DeleteUserAsync(userId);
                PopulateGrid();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Chose witch user to delete");
            }
        }

        private void btn_AddUserToRole_Click(object sender, EventArgs e)
        {
            try
            {
                var userId = gv_UsersList.SelectedRows[0].Cells["Id"].Value.ToString();
                var user = this.userManger.GetUserInfo(userId);
                if (!Utils.FormIsOpen(nameof(AddUserToRole)))
                {
                    var addUserToRole = this.formFactory.CreateAddUserToRoleForm(user);
                    addUserToRole.Show();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Pick a user");
            }
        }

        private void btn_RemoveUserFromRole_Click(object sender, EventArgs e)
        {
            try
            {
                var userId = gv_UsersList.SelectedRows[0].Cells["Id"].Value.ToString();
                var user = this.userManger.GetUserInfo(userId);

                if (!Utils.FormIsOpen(nameof(RemoveUserFromRole)))
                {
                    var removeUserFromRole = this.formFactory.CreateRemoveUserFromRole(user);
                    removeUserFromRole.Show();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Pick a user");
            }
        }

        public async void PopulateGrid()
        {
            var users = await this.userManger.GetAllUsers();
            gv_UsersList.DataSource = users;
            gv_UsersList.Columns[2].HeaderText = "Created On";
        }
    }
}

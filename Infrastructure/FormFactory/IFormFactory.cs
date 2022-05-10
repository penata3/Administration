namespace Administration.Infrastructure
{
    using Administration.Data.Models;
    using Administration.Forms;

    public interface IFormFactory
    {
        LoginForm CreateLoginForm();

        MainWindow CreateMainWindow(User user, LoginForm loginFormReference);

        CreateUserForm CreateUserForm(ManageUsersFrom manageUsersFormReference);

        ChangePasswordForm CreateChangePasswordForm();

        ManageUsersFrom CreateManageUsersForm();

        AddUserToRole CreateAddUserToRoleForm(User user);

        RemoveUserFromRole CreateRemoveUserFromRole(User user);

        AddRoleForm CreateAddRoleForm();
    }
}

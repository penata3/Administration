using System.Collections.Generic;
using Administration.Data.Models;
using Administration.Forms;

namespace Administration.Infrastructure
{

    public class FormFactory : IFormFactory
    {
        static IFormFactory _provider;

        public static void SetProvider(IFormFactory provider)
        {
            _provider = provider;
        }

        public AddRoleForm CreateAddRoleForm()
        {
            return _provider.CreateAddRoleForm();
        }

        public AddUserToRole CreateAddUserToRoleForm(User user)
        {
            return _provider.CreateAddUserToRoleForm(user);
        }

        public ChangePasswordForm CreateChangePasswordForm()
        {
            return _provider.CreateChangePasswordForm();
        }

        public LoginForm CreateLoginForm()
        {
            return _provider.CreateLoginForm();
        }

        public MainWindow CreateMainWindow(User user,LoginForm loginFormReference)
        {
            return _provider.CreateMainWindow(user, loginFormReference);
        }

        public ManageUsersFrom CreateManageUsersForm()
        {
            return _provider.CreateManageUsersForm();
        }

        public RemoveUserFromRole CreateRemoveUserFromRole(User user)
        {
            return _provider.CreateRemoveUserFromRole(user);
        }

        public CreateUserForm CreateUserForm(ManageUsersFrom manageUsersForm)
        {
            return _provider.CreateUserForm(manageUsersForm);
        }
    }
}

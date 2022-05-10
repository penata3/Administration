namespace Administration.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using Administration.Data.Models;
    using Administration.Forms;

    public class FormFactoryImpl : IFormFactory
    {
        private IServiceProvider _serviceProvider;

        public FormFactoryImpl(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public AddUserToRole CreateAddUserToRoleForm(User user)
        {
            var addUserToRoleFactory =  _serviceProvider.GetRequiredService<Func<User,AddUserToRole>>();
            return addUserToRoleFactory(user);
        }

        public MainWindow CreateMainWindow(User user, LoginForm loginFromReference)
        {
            var mainWindowFormFactory = _serviceProvider.GetRequiredService<Func<User, LoginForm, MainWindow>>();
            return mainWindowFormFactory(user, loginFromReference);

        }

        public ChangePasswordForm CreateChangePasswordForm()
        {
            return _serviceProvider.GetRequiredService<ChangePasswordForm>();
        }

        public LoginForm CreateLoginForm()
        {
            return _serviceProvider.GetRequiredService<LoginForm>();
        }

     

        public ManageUsersFrom CreateManageUsersForm()
        {
            return _serviceProvider.GetRequiredService<ManageUsersFrom>();
        }

        public CreateUserForm CreateUserForm(ManageUsersFrom manageUsersForm)
        {
            var createUserFormFactory = _serviceProvider.GetRequiredService<Func<ManageUsersFrom, CreateUserForm>>();
            return createUserFormFactory(manageUsersForm);
        }

        public RemoveUserFromRole CreateRemoveUserFromRole(User user)
        {
            var factory = _serviceProvider.GetRequiredService<Func<User, RemoveUserFromRole>>();
            return factory(user);
        }

        public AddRoleForm CreateAddRoleForm()
        {
            return _serviceProvider.GetRequiredService<AddRoleForm>();
        }
    }
}

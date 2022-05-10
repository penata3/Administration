namespace Administration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;

    using Administration.Data.Models;
    using Administration.Forms;
    using Administration.Infrastructure;
    using Administration.Services;
    using Administration.Services.Implementations;

    public static class HostBuilderExtensions
    {

        private static IConfiguration Configuration;

        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   services.AddDbContext<AdministrationDbContext>(
                       options => options.UseSqlServer(
                       Configuration
                       .GetConnectionString("DefaultConnection"))
                       .UseLazyLoadingProxies());

                   services.AddTransient<LoginForm>();
                   services.AddTransient<AddRoleForm>();
                   services.AddTransient<ChangePasswordForm>();
                   services.AddTransient<ManageUsersFrom>();
                   services.AddTransient<IUserManager, UserManager>();
                   services.AddTransient<IRoleManager, RoleManager>();
                   services.AddTransient<IFormFactory, FormFactory>();
                   services.AddTransient<Func<ManageUsersFrom, CreateUserForm>>
                   (
                       container =>
                       manageUsersForm =>
                       {
                           var roleManager = container.GetRequiredService<IRoleManager>();
                           var userManager = container.GetRequiredService<IUserManager>();
                           return new CreateUserForm(userManager, roleManager, manageUsersForm);
                       }
                       );

                   services.AddTransient<Func<User, LoginForm, MainWindow>>(
                       container =>
                     (user, loginForm) =>
                     {
                         var roleManager = container.GetRequiredService<IRoleManager>();
                         var formFactory = container.GetRequiredService<IFormFactory>();
                         return new MainWindow(user, loginForm, roleManager,formFactory);
                     });

                   services.AddTransient<Func<User, AddUserToRole>>
                   (
                       container =>
                       user =>
                       {
                           var roleManager = container.GetRequiredService<IRoleManager>();
                           return new AddUserToRole(user, roleManager);
                       }
                       );
                   services.AddTransient<Func<User, RemoveUserFromRole>>
                  (
                      container => user =>
                      {
                          var roleManager = container.GetRequiredService<IRoleManager>();
                          return new RemoveUserFromRole(user, roleManager);
                      }
                      );
               });
        }


       public static IFormFactory CompositionRoot()
        {

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = configurationBuilder.Build();

            var hostBuilder = CreateHostBuilder();
            var host = hostBuilder.Build();

            var serviceProvider = host.Services;

            var formFactory = new FormFactoryImpl(serviceProvider);
            FormFactory.SetProvider(formFactory);

            return formFactory;
        }
    }
}

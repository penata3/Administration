namespace Administration.Services.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Administration.Data.Models;
    using Administration.View_Models;

    public class UserManager : IUserManager
    {
        private readonly AdministrationDbContext dbContext;
        private readonly IRoleManager roleManager;

        public UserManager(AdministrationDbContext dbContext, IRoleManager roleManager)
        {
            this.dbContext = dbContext;
            this.roleManager = roleManager;
        }

        public async Task ChangePasswordAsync(string userId, string newPassword)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.Id == userId);

            var newPasswordHash = this.ComputeHash(newPassword);

            user.PasswordHash = newPasswordHash;

            await this.dbContext.SaveChangesAsync();
        }

        public bool ChekIfNameExists(string username)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.Username == username);
            return user != null ? true : false;
        }

        public string ComputeHash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async Task CreateUserAsync(string username, string password, IEnumerable<string> rolesNames)
        {
            var passwordHash = this.ComputeHash(password);

            var user = new User()
            {
                Username = username,
                PasswordHash = passwordHash,
            };

            await this.dbContext.Users.AddAsync(user);

            foreach (var role in rolesNames)
            {
                var roleId = this.roleManager.GetRoleByName(role).Id;

                user.Roles.Add(new UserRole
                {
                    RoleId = roleId,
                    User = user
                });
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string userId)
        {
            var userToDelete = this.dbContext.Users.FirstOrDefault(x => x.Id == userId);
            this.dbContext.Users.Remove(userToDelete);

            await this.dbContext.SaveChangesAsync();
        }

        public User Login(string username, string password)
        {
            var passwordHash = this.ComputeHash(password);
            var user = this.dbContext.Users.Where(u => u.IsDeleted == false).FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);

            return user;
        }

        public IEnumerable<string> GetAllRolesForUser(string username)
        {
            var roles = this.dbContext.UserRoles.Where(ur => ur.User.Username == username).Select(x => x.Role.Name);
            return roles;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            var users = await this.dbContext.Users.Where(u => u.IsDeleted == false)
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    CreatedOn = u.CreatedOn,
                })
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();
            return users;
        }

        public User GetUserInfo(string userId)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.Id == userId);

            return user;
        }
    }
}

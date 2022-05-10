namespace Administration.Services.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Administration.Data.Models;
    using Administration.View_Models;

    class RoleManager : IRoleManager
    {
        private readonly AdministrationDbContext dbContext;

        public RoleManager(AdministrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddUserToRole(string userID, string roleName)
        {
            var user = this.dbContext.Users.FirstOrDefault(u => u.Id == userID);
            var role = this.dbContext.Roles.FirstOrDefault(r => r.Name == roleName);

            user.Roles.Add(new UserRole()
            {
                UserId = user.Id,
                RoleId = role.Id,
            });

            await this.dbContext.SaveChangesAsync();
        }

        public async Task CreateRoleAsync(string roleName)
        {
            var role = new Role()
            {
                Name = roleName,
            };

            await this.dbContext.Roles.AddAsync(role);
            await this.dbContext.SaveChangesAsync();
        }        

        public async Task<IEnumerable<RoleViewModel>> GetAllRolesAsync()
        {
            var roles = await this.dbContext.Roles.Select(r => new RoleViewModel
            {
                Id = r.Id,
                Name = r.Name,
            })
               .ToListAsync();
            return roles;
        }

        public IEnumerable<string> GetAllRolesForUser(string userId)
        {

            var roles = this.dbContext.UserRoles.Where(ur => ur.User.Id == userId).Select(x => x.Role.Name);
            return roles;
        }

        public Role GetRoleByName(string roleName)
        {
            var role = this.dbContext.Roles.FirstOrDefault(r => r.Name == roleName);
            return role;
        }

        public IEnumerable<string> GetRolesUserNotIn(string userId)
        {
            var roles = this.dbContext.Roles.Where(r => r.Users.All(u => u.User.Id != userId)).Select(r => r.Name);
            return roles;
        }

        public bool IsUserInRole(string username, string roleName)
        {
            var user = this.dbContext.Users.FirstOrDefault(u => u.Username == username);
            return user.Roles.Any(x => x.Role.Name == roleName);
        }

        public async Task RemoveUserFromRole(string userId, string roleName)
        {
            var userRole = this.dbContext.UserRoles.FirstOrDefault(ur => ur.UserId == userId && ur.Role.Name == roleName);
            this.dbContext.UserRoles.Remove(userRole);
            await this.dbContext.SaveChangesAsync();
        }

        public bool RoleExists(string roleName)
        {
            var role = this.dbContext.Roles.FirstOrDefault(r => r.Name == roleName);
            return role != null ? true : false;        
        }
    }

}

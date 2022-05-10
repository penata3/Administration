namespace Administration.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Administration.Data.Models;
    using Administration.View_Models;

    public interface IRoleManager
    {
        Task<IEnumerable<RoleViewModel>> GetAllRolesAsync();

        Role GetRoleByName(string roleName);

        IEnumerable<string> GetRolesUserNotIn(string userId);

        IEnumerable<string> GetAllRolesForUser(string userId);

        Task CreateRoleAsync(string roleName);

        Task AddUserToRole(string username, string roleName);

        Task RemoveUserFromRole(string userId, string roleName);

        bool RoleExists(string roleName);

        bool IsUserInRole(string username,string roleName);
    }
}

namespace Administration.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Administration.Data.Models;
    using Administration.View_Models;

    public interface IUserManager
    {
        User Login(string username, string password);

        User GetUserInfo(string userId);

        Task CreateUserAsync(string username, string password,IEnumerable<string> rolesNames);

        Task ChangePasswordAsync(string userId, string newPassword);

        Task DeleteUserAsync(string userId);

        Task<IEnumerable<UserViewModel>> GetAllUsers();

        bool ChekIfNameExists(string username);

        string ComputeHash(string rawData);
    }
}

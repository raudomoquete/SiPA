using Microsoft.AspNetCore.Identity;
using SiPA.Web.Data.Entities;
using SiPA.Web.Models;
using System.Threading.Tasks;

namespace SiPA.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
        Task<bool> DeleteUserAsync(string email);
        Task<IdentityResult> UpdateUserAsync(User user);
    }
}

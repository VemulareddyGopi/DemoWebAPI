using SirIthara.Api.Models;

namespace SirIthara.Api.Services;

public interface IUserService
{
    Task<List<AdoUser>> UsersAsync();
    Task<AdoUser> UserByIdAsync(int id);
    Task<string> SaveUserAsync(AdoUser user);
    Task<AdoUser> UpdateUserAsync(AdoUser user);
    Task<bool> DeleteUserAsync(int id);
}

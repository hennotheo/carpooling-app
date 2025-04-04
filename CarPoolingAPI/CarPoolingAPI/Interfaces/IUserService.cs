using CarPoolingAPI.DTO;
using CarPoolingAPICore.Models;

namespace CarPoolingAPI.Services;

public interface IUserService : IDisposable, IAsyncDisposable
{
    Task<ICollection<UserProfileDto>> SearchUsers(int maxCount);
    Task<UserProfileDto> GetUserById(int userId);
    
    Task<UserProfileDto> AddUser(User user);
    Task DeleteUser(int userId);
}
using CarPoolingAPICore.Models;

namespace CarPoolingAPI.Services;

public interface IUserService : IDisposable, IAsyncDisposable
{
    Task<IList<User>> SearchUsers(int maxCount);
    Task<User> GetUserById(int userId);
    
    Task<User> AddUser(User user);
    Task DeleteUser(int userId);
}
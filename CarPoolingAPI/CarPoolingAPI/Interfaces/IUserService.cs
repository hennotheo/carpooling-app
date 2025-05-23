using CarPoolingAPI.DTO;
using CarPoolingAPICore.Models;

namespace CarPoolingAPI.Services;

public interface IUserService : IDisposable, IAsyncDisposable
{
    Task<ICollection<UserProfileResultDto>> SearchUsers(int maxCount);
    Task<UserProfileResultDto> GetUserById(int userId);
    
    Task<User> GetFirstByPredicate(Func<User, bool> predicate);
    
    Task<User> AddUser(User user);
    Task DeleteUser(int userId);
}
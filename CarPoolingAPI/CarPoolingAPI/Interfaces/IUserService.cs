using CarPoolingAPI.DTO;
using CarPoolingAPICore.Models;

namespace CarPoolingAPI.Services;

public interface IUserService : IDisposable, IAsyncDisposable
{
    Task<ICollection<UserProfileResultDto>> SearchUsers(int maxCount);
    Task<UserProfileResultDto> GetUserById(int userId);
    
    Task<UserProfileResultDto> AddUser(UserSignUpRequestDto userDto);
    Task DeleteUser(int userId);
}
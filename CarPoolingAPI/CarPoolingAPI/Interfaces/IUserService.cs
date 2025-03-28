using CarPoolingAPICore.Models;

namespace CarPoolingAPI.Services;

public interface IUserService : IDisposable, IAsyncDisposable
{
    IList<User>? GetAllUsers();
}
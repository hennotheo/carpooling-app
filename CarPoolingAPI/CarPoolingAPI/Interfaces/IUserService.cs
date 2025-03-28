using CarPoolingAPICore.Models;

namespace CarPoolingAPI.Services;

public interface IUserService
{
    IList<UserController>? GetAllUsers();
}
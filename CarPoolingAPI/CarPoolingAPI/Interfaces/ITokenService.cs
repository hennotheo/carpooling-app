using CarPoolingAPICore.Models;

namespace CarPoolingAPI.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}
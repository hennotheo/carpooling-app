using CarPoolingAPI.DTO;

namespace CarPoolingAPI.Services;

public interface IAuthenticationService : IDisposable, IAsyncDisposable
{
    Task<UserRegisterResponseDto> Register(UserRegisterRequestDto registerModel);
    Task<UserLoginResponseDto> Login(UserLoginDto loginModel);
}
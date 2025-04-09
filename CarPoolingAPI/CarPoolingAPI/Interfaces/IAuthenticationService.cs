using CarPoolingAPI.DTO;

namespace CarPoolingAPI.Services;

public interface IAuthenticationService : IDisposable, IAsyncDisposable
{
    Task<UserAuthResponseDto> Register(UserRegisterRequestDto registerModel);
    Task<UserAuthResponseDto> Login(UserLoginRequestDto loginRequestModel);
}
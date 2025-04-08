using System.Text.RegularExpressions;
using CarPoolingAPI.DTO;
using CarPoolingAPI.Exceptions;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;

namespace CarPoolingAPI.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public AuthenticationService(ITokenService tokenService, IUserService userService)
    {
        _tokenService = tokenService;
        _userService = userService;
    }

    public async Task<UserRegisterResponseDto> Register(UserRegisterRequestDto registerModel)
    {
        if (!CheckNameString(registerModel.FirstName))
            throw new BadRequestServiceException("First Name Invalid");

        if (!CheckNameString(registerModel.LastName))
            throw new BadRequestServiceException("Last Name Invalid");

        if (!CheckEmailString(registerModel.Email))
            throw new BadRequestServiceException("Email Invalid");

        if (!CheckPasswordString(registerModel.Password))
            throw new BadRequestServiceException("Password Invalid");

        User user = registerModel.MapToUser();
        await _userService.AddUser(user);
        string token = _tokenService.GenerateToken(user);
        
        return new UserRegisterResponseDto()
        {
            Token = token,
            UserId = user.Id
        };
    }

    public Task<UserLoginResponseDto> Login(UserLoginDto loginModel)
    {
        throw new NotImplementedException();
    }

    private bool CheckNameString(string value)
    {
        if (string.IsNullOrWhiteSpace(value) ||
            value.Length < 2 ||
            value.Length > 20 ||
            !Regex.IsMatch(value, @"^[A-Za-zÀ-ÖØ-öø-ÿ\-]+$"))
            return false;

        return true;
    }

    private bool CheckEmailString(string email)
    {
        if (string.IsNullOrWhiteSpace(email) ||
            !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            return false;

        return true;
    }

    private bool CheckPasswordString(string password)
    {
        if (string.IsNullOrWhiteSpace(password) ||
            password.Length < 8 || // Minimum length
            password.Length > 20 || // Maximum length
            !Regex.IsMatch(password, @"[A-Z]") || // At least one uppercase letter
            !Regex.IsMatch(password, @"[a-z]") || // At least one lowercase letter
            !Regex.IsMatch(password, @"\d") || // At least one digit
            !Regex.IsMatch(password, @"[\W_]")) // At least one special character
            return false;

        return true;
    }

    public void Dispose()
    {
        _userService.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _userService.DisposeAsync();
    }
}
using System.Text;
using System.Text.RegularExpressions;
using CarPoolingAPI.Exceptions;
using CarPoolingAPICore.Models;
using CarPoolingAPI.DTO;

namespace CarPoolingAPI.Services;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public AuthenticationService(ITokenService tokenService, IUserService userService)
    {
        _tokenService = tokenService;
        _userService = userService;
    }

    public async Task<UserAuthResponseDto> Register(UserRegisterRequestDto registerModel)
    {
        if (!CheckNameString(registerModel.FirstName))
            throw new BadRequestServiceException("First Name Invalid");

        if (!CheckNameString(registerModel.LastName))
            throw new BadRequestServiceException("Last Name Invalid");

        if (!CheckEmailString(registerModel.Email))
            throw new BadRequestServiceException("Email Invalid");

        if (!CheckPasswordString(registerModel.Password))
            throw new BadRequestServiceException("Password Invalid");

        registerModel.Password = HashPassword(registerModel.Password);
        
        User user = registerModel.MapToUser();
        user = await _userService.AddUser(user);
        string token = _tokenService.GenerateToken(user);

        return new UserAuthResponseDto()
        {
            Token = token,
            UserId = user.Id
        };
    }

    public async Task<UserAuthResponseDto> Login(UserLoginRequestDto loginRequestModel)
    {
        User targetUser = await _userService.GetFirstByPredicate(user => user.Email == loginRequestModel.Email);
        loginRequestModel.Password = HashPassword(loginRequestModel.Password);

        if (loginRequestModel.Password != targetUser.HashedPassword)
            throw new UnAuthorizedServiceException($"Invalid Password");

        return new UserAuthResponseDto()
        {
            Token = _tokenService.GenerateToken(targetUser),
            UserId = targetUser.Id
        };
    }

    private string HashPassword(string password)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
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
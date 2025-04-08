using CarPoolingAPI.DTO;
using CarPoolingAPI.Services;
using CarPoolingAPICore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] UserRegisterRequestDto registerModel)
    {
        User user = registerModel.MapToUser();

        string token = _tokenService.GenerateToken(user);
        return Ok(new UserRegisterResponseDto { Token = token, UserId = user.Id });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginDto loginModel)
    {
        User user = AuthenticateUser(loginModel);
        if (user == null)
        {
            return Unauthorized();
        }

        string token = _tokenService.GenerateToken(user);
        return Ok(new { Token = token });
    }

    private User AuthenticateUser(UserLoginDto loginModel)
    {
        return new User { FirstName = "testuser", Email = "testuser@example.com" };
    }
}
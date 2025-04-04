using CarPoolingAPI.DTO;
using CarPoolingAPI.Services;
using CarPoolingAPICore.Models;
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

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginDto loginModel)
    {
        // Validation des informations d'identification de l'utilisateur
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
        // Logique de validation des informations d'identification de l'utilisateur
        // Retourner l'objet utilisateur si les informations sont valides
        return new User { FirstName = "testuser", Email = "testuser@example.com" };
    }
}
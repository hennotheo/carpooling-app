using CarPoolingAPI.DTO;
using CarPoolingAPI.Services;
using CarPoolingAPICore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : CarPoolingAPIController<AuthController>
{
    private readonly ITokenService _tokenService;
    private readonly IAuthenticationService _authenticationService;

    public AuthController(ITokenService tokenService, IAuthenticationService authenticationService, ILogger<AuthController> logger) : base(logger)
    {
        _tokenService = tokenService;
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto registerModel)
    {
        return await ExecuteServiceAction(async () =>
        {
            UserAuthResponseDto response = await _authenticationService.Register(registerModel);
            return Ok(response);
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginRequestModel)
    {
        return await ExecuteServiceAction(async () =>
        {
            UserAuthResponseDto response = await _authenticationService.Login(loginRequestModel);
            return Ok(response);
        });
    }
}
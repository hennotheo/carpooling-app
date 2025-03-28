using CarPoolingAPI.Services;
using CarPoolingAPICore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolingAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet(Name = "GetUsers")]
    public IActionResult Get()
    {
        ICollection<CarPoolingAPICore.Models.User>? allUsers = _userService.GetAllUsers();
        if (allUsers != null)
            return Ok(allUsers);

        return NotFound();
    }
}
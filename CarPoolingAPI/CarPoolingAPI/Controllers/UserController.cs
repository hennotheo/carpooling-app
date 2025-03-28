using System.ComponentModel.DataAnnotations;
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
    public IActionResult Search([FromQuery, Range(1, 100)] int max = 25)
    {
        ICollection<User> allUsers = _userService.SearchUsers(max);
        if (allUsers != null && allUsers.Count > 0)
            return Ok(allUsers);

        return NotFound();
    }
}
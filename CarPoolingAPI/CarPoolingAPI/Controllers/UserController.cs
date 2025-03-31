using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using CarPoolingAPI.Services;
using CarPoolingAPICore.Exceptions;
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

    [HttpGet("Search", Name = "SearchUsers")]
    public IActionResult Search([FromQuery, DefaultParameterValue(25), Optional, Range(1, 100)] int max)
    {
        ICollection<User> allUsers = _userService.SearchUsers(max);

        if (allUsers.Count > 0)
            return Ok(allUsers);

        return NotFound();
    }

    [HttpGet("{userId}", Name = "GetUser")]
    public IActionResult GetUserById([FromRoute, Range(0, int.MaxValue)] int userId)
    {
        try
        {
            User user = _userService.GetUserById(userId);
            return Ok(user);
        }
        catch (RepoDataNotFoundException e)
        {
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}
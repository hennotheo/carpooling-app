using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using CarPoolingAPI.Exceptions;
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
        ICollection<User> allUsers = _userService.SearchUsers(max).Result;

        if (allUsers.Count > 0)
            return Ok(allUsers);

        return NotFound();
    }

    [HttpGet("{userId}", Name = "GetUser")]
    public IActionResult GetUserById([FromRoute, Range(0, int.MaxValue)] int userId)
    {
        return ExecuteServiceAction(() =>
        {
            User user = _userService.GetUserById(userId).Result;
            return Ok(user);
        });
    }

    [HttpDelete("{userId}", Name = "DeleteUser")]
    public IActionResult DeleteUserById([FromRoute, Range(0, int.MaxValue)] int userId)
    {
        return ExecuteServiceAction(() =>
        {
            _userService.DeleteUser(userId).Wait();
            return Ok("User deleted successfully");
        });
    }
    
    private IActionResult ExecuteServiceAction(Func<IActionResult>? action)
    {
        if (action == null)
            return BadRequest("Action is null");
        
        try
        {
            return action();
        }
        catch (AggregateException e)
        {
            _logger.LogError(e.Message);
            
            if (e.InnerException is ServiceException)
            {
                return (e.InnerException! as ServiceException)!.ErrorAction();
            }

            return BadRequest();
        }
    }
}
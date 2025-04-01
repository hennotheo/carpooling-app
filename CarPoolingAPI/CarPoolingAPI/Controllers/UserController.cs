using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using CarPoolingAPI.Exceptions;
using CarPoolingAPI.Services;
using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public async Task<IActionResult> Search([FromQuery, DefaultParameterValue(25), Optional, Range(1, 100)] int max)
    {
        ICollection<User> allUsers = await _userService.SearchUsers(max);

        if (allUsers.Count > 0)
            return Ok(allUsers);

        return NotFound();
    }

    [HttpGet("{userId}", Name = nameof(GetUserById))]
    public async Task<IActionResult> GetUserById([FromRoute, Range(0, int.MaxValue)] int userId)
    {
        return await ExecuteServiceAction(async () =>
        {
            User user = await _userService.GetUserById(userId);
            return Ok(user);
        });
    }

    [HttpDelete("{userId}", Name = "DeleteUser")]
    public async Task<IActionResult> DeleteUserById([FromRoute, Range(0, int.MaxValue)] int userId)
    {
        return await ExecuteServiceAction(async () =>
        {
            await _userService.DeleteUser(userId);
            return Ok("User deleted successfully");
        });
    }

    [HttpPost(Name = "AddUser")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        return await ExecuteServiceAction(async () =>
        {
            User createdUser = await _userService.AddUser(user);
            return CreatedAtRoute("GetUserById", new { userId = createdUser.Id }, createdUser);
        });
    }

    private async Task<IActionResult> ExecuteServiceAction(Func<Task<IActionResult>>? action)
    {
        if (action == null)
            return BadRequest("Action is null");

        try
        {
            return await action();
        }
        catch (ServiceException e)
        {
            _logger.LogError(e.StackTrace);
            return e.ErrorAction();
        }
        catch(Exception e)
        {
            _logger.LogError(e.StackTrace);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
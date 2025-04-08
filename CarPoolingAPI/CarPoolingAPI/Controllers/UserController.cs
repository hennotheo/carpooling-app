using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using CarPoolingAPI.DTO;
using CarPoolingAPI.Exceptions;
using CarPoolingAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : CarPoolingAPIController<UserController>
{
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService) : base(logger)
    {
        _userService = userService;
    }

    [HttpGet("Search", Name = "SearchUsers")]
    public async Task<IActionResult> Search([FromQuery, DefaultParameterValue(25), Optional, Range(1, 100)] int max)
    {
        ICollection<UserProfileResultDto> allUsers = await _userService.SearchUsers(max);

        if (allUsers.Count > 0)
            return Ok(allUsers);

        return NoContent();
    }

    [HttpGet("{userId}", Name = nameof(GetUserById))]
    public async Task<IActionResult> GetUserById([FromRoute, Range(0, int.MaxValue)] int userId)
    {
        return await ExecuteServiceAction(async () =>
        {
            UserProfileResultDto user = await _userService.GetUserById(userId);
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
}
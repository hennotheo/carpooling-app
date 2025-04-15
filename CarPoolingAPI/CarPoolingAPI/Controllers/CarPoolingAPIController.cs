using CarPoolingAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolingAPI.Controllers;

public abstract class CarPoolingAPIController<T> : ControllerBase where T : CarPoolingAPIController<T>
{
    protected readonly ILogger<T> Logger;
    
    protected CarPoolingAPIController(ILogger<T> logger)
    {
        Logger = logger;
    }
    
    protected async Task<IActionResult> ExecuteServiceAction(Func<Task<IActionResult>>? action)
    {
        if (action == null)
            return BadRequest("Action is null");

        try
        {
            return await action();
        }
        catch (ServiceException e)
        {
            Logger.LogError(e.StackTrace);
            return e.ErrorAction();
        }
        catch(Exception e)
        {
            Logger.LogError(e.StackTrace);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
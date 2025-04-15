using Microsoft.AspNetCore.Mvc;

namespace CarPoolingAPI.Exceptions;

public class ConflictServiceException : ServiceException
{
    public ConflictServiceException(string message) : base(message)
    {
    }
    
    public override IActionResult ErrorAction()
    {
        return new BadRequestObjectResult(Message);
    }
}
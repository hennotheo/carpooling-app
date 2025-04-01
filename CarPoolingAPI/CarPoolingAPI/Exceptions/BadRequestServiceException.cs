using Microsoft.AspNetCore.Mvc;

namespace CarPoolingAPI.Exceptions;

public class BadRequestServiceException : ServiceException
{
    public BadRequestServiceException(string message) : base(message)
    {
    }
    
    public override IActionResult ErrorAction()
    {
        return new BadRequestObjectResult(Message);
    }
}
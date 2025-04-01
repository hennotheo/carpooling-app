using Microsoft.AspNetCore.Mvc;

namespace CarPoolingAPI.Exceptions;

public class NotFoundServiceException : ServiceException
{
    public NotFoundServiceException(string message) : base(message)
    {
    }
    
    public override IActionResult ErrorAction()
    {
        return new NotFoundObjectResult(Message);
    }
}
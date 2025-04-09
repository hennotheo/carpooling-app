using Microsoft.AspNetCore.Mvc;

namespace CarPoolingAPI.Exceptions;

public class UnAuthorizedServiceException : ServiceException
{
    public UnAuthorizedServiceException(string message) : base(message)
    {
    }
    
    public override IActionResult ErrorAction()
    {
        return new UnauthorizedObjectResult(Message);
    }
}
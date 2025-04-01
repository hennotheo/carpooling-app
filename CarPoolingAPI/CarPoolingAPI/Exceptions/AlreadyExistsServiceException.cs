using Microsoft.AspNetCore.Mvc;

namespace CarPoolingAPI.Exceptions;

public class AlreadyExistsServiceException : ServiceException
{
    public AlreadyExistsServiceException(string message) : base(message)
    {
    }
    
    public override IActionResult ErrorAction()
    {
        return new ConflictObjectResult(Message);
    }
}
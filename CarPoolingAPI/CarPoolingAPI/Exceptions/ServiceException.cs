using Microsoft.AspNetCore.Mvc;

namespace CarPoolingAPI.Exceptions;

public abstract class ServiceException : Exception
{
    public ServiceException(string message) : base(message)
    {
    }
    
    public abstract IActionResult ErrorAction();
}
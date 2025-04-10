using System.Text.RegularExpressions;
using CarPoolingAPICore.Models;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CarPoolingAPI.DTO;

public struct UserRegisterRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public static UserRegisterRequestDto MapFromUser(User user)
    {
        return new UserRegisterRequestDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }

    public User MapToUser()
    {
        return new User()
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            HashedPassword = Password
        };
    }
}
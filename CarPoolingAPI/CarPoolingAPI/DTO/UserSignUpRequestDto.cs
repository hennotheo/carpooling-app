using CarPoolingAPICore.Models;

namespace CarPoolingAPI.DTO;

public struct UserSignUpRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public static UserSignUpRequestDto MapFromUser(User user)
    {
        return new UserSignUpRequestDto()
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
            Email = Email
        };
    }
}
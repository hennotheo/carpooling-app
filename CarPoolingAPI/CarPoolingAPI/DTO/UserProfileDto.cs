using CarPoolingAPICore.Models;

namespace CarPoolingAPI.DTO;

public struct UserProfileDto
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public static UserProfileDto MapFromUser(User user)
    {
        return new UserProfileDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }
}
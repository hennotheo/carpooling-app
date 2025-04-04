using CarPoolingAPICore.Models;

namespace CarPoolingAPI.DTO;

public struct UserProfileResultDto
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public static UserProfileResultDto MapFromUser(User user)
    {
        return new UserProfileResultDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }
}
namespace CarPoolingAPI.DTO;

public class UserLoginVerifDto
{
    public int UserId { get; set; }
    public string HashedPassword { get; set; }
}
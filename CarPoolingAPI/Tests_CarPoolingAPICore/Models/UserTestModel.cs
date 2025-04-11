namespace Tests_CarPoolingAPICore.Models;

public class UserTestModel//Without Constraints
{
    public int Id { get; set; }
    
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
}
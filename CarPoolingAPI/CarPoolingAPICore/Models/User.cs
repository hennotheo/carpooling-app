using System.ComponentModel.DataAnnotations;

namespace CarPoolingAPICore.Models;

public class User
{
    public int Id { get; set; }

    [Required, MaxLength(20), MinLength(3)]
    public string FirstName { get; set; }

    [MaxLength(20)] public string LastName { get; set; }

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; }

    [Required] 
    public string HashedPassword { get; set; }
}
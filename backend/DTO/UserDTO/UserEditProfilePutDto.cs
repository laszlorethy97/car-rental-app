using System;
namespace CarRentalSystem;


public class UserEditProfilePutDto
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

}

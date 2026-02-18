namespace CarRentalSystem;

public class User
{
    public int Id {get; set;}
    public string? Email {get; set;}
    public string? Password {get; set;}
    public string? UserName {get; set;}
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public string? PhoneNumber {get; set;}
    public string? Address {get; set;}
    public UserRole UserRole {get; set;}
    public ICollection<Rental> Rentals {get; set;} = new List<Rental>();
    public ICollection<Rental> ApprovedRentals { get; set; } = new List<Rental>();
}
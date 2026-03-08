namespace CarRentalSystem;

public class RegistrationUserPostDTO
{
    public string Email {get; set;}
    public string Password {get; set;}
    public string UserName {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string PhoneNumber {get; set;}
    public string Address {get; set;}
    public ICollection<int> RoleIds {get; set;} = new List<int>();
}
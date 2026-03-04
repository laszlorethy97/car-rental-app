using System.Data.Common;

namespace CarRentalSystem;

public class Role
{
    public int Id {get; set;}
    public UserRole RoleType {get; set;}
    public ICollection<User> Users {get; set;} = new List<User>();
}
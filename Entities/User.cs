namespace CarRentalSystem;

public class User
{
    public int _id;
    public string? _email;
    public string? _password;
    public string? _userName;
    public string? _firstName;
    public string? _lastName;
    public int _phoneNumber;
    public string? _address;
    public UserRole _userRole;
    public bool _isRegistered;

    public User(int id, string? email, string? password, string? userName, string? firstName, string? lastName, int phoneNumber, string? address, UserRole userRole, bool isRegistered)
    {
        _id = id;
        _email = email;
        _password = password;
        _userName = userName;
        _firstName = firstName;
        _lastName = lastName;
        _phoneNumber = phoneNumber;
        _address = address;
        _userRole = userRole;
        _isRegistered = isRegistered;
    }
}
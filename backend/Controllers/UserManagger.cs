using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CarRentalSystem;

[ApiController]
[Route("api/CarRental")]
public class UserController: ControllerBase
{
    UserManager managger;
    public UserController(UserManager managger)
    {
        this.managger = managger;
    }

    [HttpGet("users", Name = "GetUsers")]
    async public Task<List<User>> GetUsers()
    {
        return await managger.GetUsers();
    }

    [HttpGet("user/{id}", Name = "GetUser")]
    async public Task<User?> GetUserById(int id)
    {
        return await managger.GetUserById(id);
    }

    [HttpPost("user", Name = "AddUser")]
    async public Task AddUser(User user)
    {
        await managger.AddUser(user);
    }

    [HttpPut("user/{id}", Name = "Updateuser")]
    public async Task UpdateUser(int id, [FromBody] User user)
    {
        await managger.UpdateUser(id, user);
    }
}
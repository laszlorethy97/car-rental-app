using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CarRentalSystem;

[ApiController]
[Route("api/CarRental")]
public class UserController: ControllerBase
{
    UserManager manager;
    public UserController(UserManager manager)
    {
        this.manager = manager;
    }

    [HttpGet("users", Name = "GetUsers")]
    async public Task<List<User>> GetUsers()
    {
        return await manager.GetUsers();
    }

    [HttpGet("user/{id}", Name = "GetUser")]
    async public Task<User?> GetUserById(int id)
    {
        return await manager.GetUserById(id);
    }

    [HttpPost("user", Name = "AddUser")]
    async public Task AddUser(User user)
    {
        await manager.AddUser(user);
    }

    [HttpPut("user/{id}", Name = "Updateuser")]
    public async Task UpdateUser(int id, [FromBody] User user)
    {
        await manager.UpdateUser(id, user);
    }
}
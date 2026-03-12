using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CarRentalSystem;

[ApiController]
[Route("api/CarRental/user")]
public class UserController: ControllerBase
{
    UserManager manager;
    public UserController(UserManager manager)
    {
        this.manager = manager;
    }

    [HttpGet("user", Name = "GetUsers")]
    async public Task<List<User>> GetUsers()
    {
        return await manager.GetUsers();
    }

    [HttpGet("name/{id}", Name = "GetUser")]
    async public Task<IActionResult> GetUserById(int id)
    {
        EditProfileGetDTO dto = await manager.GetUserById(id);
        return Ok(dto);
    }

    [HttpPost("registration", Name = "AddUser")]
    async public Task<IActionResult> AddUser(RegistrationUserPostDTO registrationUserPostDTO)
    {
        bool succes = await manager.Registration(registrationUserPostDTO);
        if (!succes)
        {
            return BadRequest(new { message = "The username or email is already taken." });
        }
        return Ok(new { message = "Registration successful." }); 
    }

    [HttpPost("login", Name = "LoginUser")]
    public async Task<IActionResult> Login(LoginUserPostDTO loginUserPostDTO)
    {
        bool succes = await this.manager.LoginUser(loginUserPostDTO);
        if (!succes)
        {
            return BadRequest(new { message = "Invalid username or password." });
        }
        return Ok(new { message = "Login successful" });
    }

    [HttpPut("user/{id}", Name = "Updateuser")]
    public async Task UpdateUser(int id, [FromBody] User user)
    {
        await manager.UpdateUser(id, user);
    }
}
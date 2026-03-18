using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;



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

    [HttpGet("name")]
    [Authorize]
    public async Task<IActionResult> GetUserByToken()
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null) return Unauthorized("Invalid token: no user ID");
        int userId = int.Parse(userIdClaim);
        EditProfileGetDTO dto = await manager.GetUserById(userId);
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
        string? token = await this.manager.LoginUser(loginUserPostDTO);
        if (token == null)
        {
            return BadRequest(new { message = "Invalid username or password." });
        }
        return Ok(new { message = token });
    }

    
    [HttpPut("editProfile")]
    [Authorize]
    public async Task<IActionResult> UpdateUser([FromBody] UserEditProfilePutDto dto)
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null) return Unauthorized("Invalid token: no user ID");
        int userId = int.Parse(userIdClaim);

        bool success = await manager.UpdateExistingUser(userId, dto);
        if (!success)
        {
            return BadRequest(new { message = "Update failed!" });
        }
        return Ok(new { message = "Update successful!" });
    }

}
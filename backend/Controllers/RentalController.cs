using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CarRentalSystem;

[ApiController]
[Route("api/CarRental/rental")]
public class RentalController: ControllerBase
{
    RentalManager manager;
    public RentalController(RentalManager manager)
    {
        this.manager = manager;
    }


    [HttpGet("rental/{id}", Name = "GetRental")]
    async public Task<Rental?> GetRentalById(int id)
    {
        return await manager.GetRentalById(id);
    }

    [HttpPost("rental", Name = "AddRental")]
    [Authorize]
    async public Task<IActionResult> AddRental(RentalPostDTO RPD)
    {
        int userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
        bool success = await manager.AddRental(RPD, userId);

        if (!success)
        {
            return BadRequest(new {message = "Car is under maintenace period"});
        }

        return Ok(new {message = "Rental request accepted"});
    }
    

    [HttpPut("rental/{id}", Name = "UpdateRental")]
    public async Task UpdateRentalByid(int id, [FromBody] Rental rental)
    {
        await manager.UpdateRentalByid(id, rental);
    }


    [HttpGet("history", Name = "GetRentalHistory")]
    [Authorize]
    public async Task <ActionResult<List<RentalHistoryGetDTO>>> GetRentalHistory()
    {
         var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
        if (userIdClaim == null) return Unauthorized("Invalid token: no user ID");
        int userId = int.Parse(userIdClaim.Value);
        return Ok(await manager.GetRentalHistory(userId));
    }

    [HttpGet("rentals", Name = "GetAllRentals")]
    [Authorize]
    public async Task <ActionResult<List<GetAllRentalsDTO>>> GetAllRentals()
    {
        return Ok(await manager.GetAllRentals());
    }
}
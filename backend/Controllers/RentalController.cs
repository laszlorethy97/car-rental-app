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

    [HttpGet("rentals", Name = "GetRentals")]
    async public Task<List<Rental>> GetRentals()
    {
        return await manager.GetRentals();
    }

    [HttpGet("rental/{id}", Name = "GetRental")]
    async public Task<Rental?> GetRentalById(int id)
    {
        return await manager.GetRentalById(id);
    }

    [HttpPost("rental", Name = "AddRental")]
    async public Task AddRental(Rental rental)
    {
        await manager.AddRental(rental);
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
}
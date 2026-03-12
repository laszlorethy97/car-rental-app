using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CarRentalSystem;

[ApiController]
[Route("api/CarRental")]
public class RentalController: ControllerBase
{
    RentalManager manager;
    public RentalController(RentalManager manager)
    {
        this.manager = manager;
    }

    [HttpGet("rentals", Name = "GetRentals")]
    async public Task<List<RentalGetDTO>> GetRentals()
    {
        return await manager.GetRentals();
    }

    [HttpGet("rental/{id}", Name = "GetRental")]
    async public Task<Rental?> GetRentalById(int id)
    {
        return await manager.GetRentalById(id);
    }

    [HttpPost("rental", Name = "AddRental")]
    async public Task AddRental(RentalPostDTO RPD)
    {
        await manager.AddRental(RPD);
    }

    [HttpPut("rental/{id}", Name = "UpdateRental")]
    public async Task UpdateRentalByid(int id, [FromBody] Rental rental)
    {
        await manager.UpdateRentalByid(id, rental);
    }
}
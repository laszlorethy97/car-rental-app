using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CarRentalSystem;

[ApiController]
[Route("api/CarRental")]
public class RentalController: ControllerBase
{
    RentalManagger managger;
    public RentalController(RentalManagger managger)
    {
        this.managger = managger;
    }

    [HttpGet("rentals", Name = "GetRentals")]
    async public Task<List<Rental>> GetRentals()
    {
        return await managger.GetRentals();
    }

    [HttpGet("rental/{id}", Name = "GetRental")]
    async public Task<Rental?> GetRentalById(int id)
    {
        return await managger.GetRentalById(id);
    }

    [HttpPost("rental", Name = "AddRental")]
    async public Task AddRental(Rental rental)
    {
        await managger.AddRental(rental);
    }

    [HttpPut("rental/{id}", Name = "UpdateRental")]
    public async Task UpdateRentalByid(int id, [FromBody] Rental rental)
    {
        await managger.UpdateRentalByid(id, rental);
    }
}
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem;

[ApiController]
[Route("api/[controller]")]
public class CarRentalController: ControllerBase
{
    Managger manager;
    public CarRentalController(Managger manager)
    {
        this.manager = manager;
    }
    
    [HttpGet(Name = "GetCars")]
    async public Task<List<Car>> GetCars()
    {
        return await manager.GetCars();
    }
}


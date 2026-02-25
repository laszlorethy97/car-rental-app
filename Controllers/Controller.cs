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
    
    [HttpGet("cars", Name = "GetCars")]
    async public Task<List<Car>> GetCars()
    {
        return await manager.GetCars();
    }

    [HttpGet("car/{id}", Name = "GetCar")]
    async public Task<Car?> GetCarById(int id)
    {
        return await manager.GetCarById(id);
    }

    [HttpPost("car", Name = "AddCar")]
    async public Task AddCar(Car car)
    {
        await manager.AddCar(car);
    }
}


using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CarRentalSystem;

[ApiController]
[Route("api/CarRental/")]
public class CarController: ControllerBase
{
    CarManager manager;
    public CarController(CarManager manager)
    {
        this.manager = manager;
    }

    [HttpGet("cars", Name = "GetCars")]
    async public Task<List<CarsGetDTO>> GetCars()
    {
        return await manager.GetCars();
    }

    [HttpGet("car/{id}", Name = "GetCar")]
    async public Task<CarsGetDTO?> GetCarById(int id)
    {
        return await manager.GetCarById(id);
    }

    [HttpPost("car", Name = "AddCar")]
    async public Task AddCar(Car car)
    {
        await manager.AddCar(car);
    }

    [HttpPut("car/{id}", Name = "UpdateCar")]
    public async Task UpdateCar(int id, [FromBody] Car car)
    {
        await manager.UpdateCar(id, car);
    }
}
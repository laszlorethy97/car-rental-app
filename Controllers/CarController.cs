using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CarRentalSystem;

[ApiController]
[Route("api/CarRental")]
public class CarController: ControllerBase
{
    CarManagger managger;
    public CarController(CarManagger managger)
    {
        this.managger = managger;
    }

    [HttpGet("cars", Name = "GetCars")]
    async public Task<List<Car>> GetCars()
    {
        return await managger.GetCars();
    }

    [HttpGet("car/{id}", Name = "GetCar")]
    async public Task<Car?> GetCarById(int id)
    {
        return await managger.GetCarById(id);
    }

    [HttpPost("car", Name = "AddCar")]
    async public Task AddCar(Car car)
    {
        await managger.AddCar(car);
    }

    [HttpPut("car/{id}", Name = "UpdateCar")]
    public async Task UpdateCar(int id, [FromBody] Car car)
    {
        await managger.UpdateCar(id, car);
    }
}
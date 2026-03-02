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

    [HttpPatch("car/{id}", Name = "UpdateCar")]
    public async Task UpdateCarByid(int id, [FromBody] Car car)
    {
        await manager.UpdateCarByid(id, car);
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

    [HttpPatch("rental/{id}", Name = "UpdateRental")]
    public async Task UpdateRentalByid(int id, [FromBody] Rental rental)
    {
        await manager.UpdateRentalByid(id, rental);
    }
}


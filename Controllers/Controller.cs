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

    [HttpPut("car/{id}", Name = "UpdateCar")]
    public async Task UpdateCar(int id, [FromBody] Car car)
    {
        await manager.UpdateCar(id, car);
    }



    /*[HttpPatch("car/{id}", Name = "UpdateCar")]
    public async Task UpdateCarByid(int id, [FromBody] Car car)
    {
        await manager.UpdateCarByid(id, car);
    }*/


    [HttpGet("users", Name = "GetUsers")]
    async public Task<List<User>> GetUsers()
    {
        return await manager.GetUsers();
    }

    [HttpGet("user/{id}", Name = "GetUser")]
    async public Task<User?> GetUserById(int id)
    {
        return await manager.GetUserById(id);
    }

    [HttpPost("user", Name = "AddUser")]
    async public Task AddUser(User user)
    {
        await manager.AddUser(user);
    }

    [HttpPut("user/{id}", Name = "Updateuser")]
    public async Task UpdateUser(int id, [FromBody] User user)
    {
        await manager.UpdateUser(id, user);
    }
}


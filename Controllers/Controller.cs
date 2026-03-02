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


   [HttpGet("invoices", Name = "GetInvoices")]
    async public Task<List<Invoice>> GetInvoice()
    {
        return await manager.GetInvoice();
    }

    [HttpGet("invoice/{id}", Name = "GetInvoice")]
    async public Task<Invoice?> GetInvoiceById(int id)
    {
        return await manager.GetInvoiceById(id);
    }

    [HttpPost("invoice", Name = "AddInvoice")]
    async public Task AddInvoice(Invoice invoice)
    {
        await manager.AddInvoice(invoice);
    }

    [HttpPut("invoice/{id}", Name = "UpdateInvoice")]
    public async Task UpdateInvoice(int id, [FromBody] Invoice invoice)
    {
        await manager.UpdateInvoice(id, invoice);
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
}


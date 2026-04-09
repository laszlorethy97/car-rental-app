using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;


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
    [Authorize]
    async public Task<CarsGetDTO?> GetCarById(int id)
    {
        return await manager.GetCarById(id);
    }

    [HttpPost("car", Name = "AddCar")]
    [Authorize]
    public async Task<IActionResult> AddCar(CarPostDTO carDTO)
    {
        var result = await manager.AddCar(carDTO);
        if (!result.success)
        {
            return BadRequest(new { message = result.reason });
        }
        return Ok(new { message = "success" });
    }

    [HttpPost("admin-maintenance-modify", Name = "AddMaintenance")]
    [Authorize]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> AddMaintenance([FromBody] MaintenancePostDTO dto)
    {
        var success = await manager.AddMaintenance(dto);
        
        if (!success.success)
        {
            return BadRequest(success.reason);
        }

        return Ok();
    }

    [HttpPut("admin-car-modify")]
    [Authorize]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> ModifyCar([FromBody] CarsGetDTO dto)
    {
        var result = await manager.ModifyCar(dto);
        
        if (!result.success)
        {
            return BadRequest(new { message = result.reason });

        }

        return Ok(new { message = "Car updated" });
    }

    [HttpDelete("admin-car-delete/{id}")]
    [Authorize]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var result = await manager.DeleteCar(id);

        if (!result.success)
            return BadRequest(new { message = result.reason });

        return Ok(new { message = "Car deleted" });
    }


}
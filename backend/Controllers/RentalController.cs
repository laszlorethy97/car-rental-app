using CarRentalSystem.DTO.RentalDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


namespace CarRentalSystem;

[ApiController]
[Route("api/CarRental/rental")]
public class RentalController: ControllerBase
{
    RentalManager manager;
    public RentalController(RentalManager manager)
    {
        this.manager = manager;
    }


    [HttpGet("rental/{id}", Name = "GetRental")]
    async public Task<Rental?> GetRentalById(int id)
    {
        return await manager.GetRentalById(id);
    }

    [HttpPost("rental", Name = "AddRental")]
    [Authorize]
    async public Task<IActionResult> AddRental(RentalPostDTO RPD)
    {
        int userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
        bool success = await manager.AddRental(RPD, userId);

        if (!success)
        {
            return BadRequest(new {message = "Car is under maintenace period"});
        }

        return Ok(new {message = "Rental request accepted"});
    }
    

    [HttpPut("rental/{id}", Name = "UpdateRental")]
    public async Task UpdateRentalByid(int id, [FromBody] Rental rental)
    {
        await manager.UpdateRentalByid(id, rental);
    }


    [HttpGet("history", Name = "GetRentalHistory")]
    [Authorize]
    public async Task <ActionResult<List<RentalHistoryGetDTO>>> GetRentalHistory()
    {
         var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
        if (userIdClaim == null) return Unauthorized("Invalid token: no user ID");
        int userId = int.Parse(userIdClaim.Value);
        return Ok(await manager.GetRentalHistory(userId));
    }

    [HttpGet("rentals", Name = "GetAllRentals")]
    [Authorize]
    public async Task <ActionResult<List<GetAllRentalsDTO>>> GetAllRentals()
    {
        return Ok(await manager.GetAllRentals());
    }

    [HttpPut("modify")]
    [Authorize]
    public async Task<IActionResult> PutRentalModify([FromBody] RentalDecisionPutDto dto)
    {
        var result = await manager.PutRentalModify(dto);

        if (!result.success)
        {
            return BadRequest(new { message = result.reason });

        }
        var rental = await manager.GetRentalById(dto.RentalId);
        if (rental == null) return BadRequest(new { message = "Rental not found!" });
        return Ok(new { message = $"Modify successful: {dto.Answer}, status: {rental.RentStatus}" });
    }

    [HttpPut("close")]
    [Authorize]
    public async Task<IActionResult> PutRentalClose([FromBody] RentalDecisionPutDto dto)
    {
        var result = await manager.CloseRental(dto);

        if(!result.success)
        {
            return BadRequest(new { message = result.reason });

        }
        var rental = await manager.GetRentalById(dto.RentalId);
        if (rental == null) return BadRequest(new { message = "Rental not found!" });
        return Ok(new { message = $"Closed :) | {dto.Answer}, status: {rental.RentStatus}" });
    }


    [HttpPost("activate")]
    [Authorize]
    public async Task<IActionResult> Activate(RentIdToInvoiceDTO dto)
    {
        var result = await manager.Active(dto);
        if (!result.success)
        {
            return BadRequest(new { message = result.reason });
        }
         return Ok(new { message = "activated successful"});
    }

    [HttpPut("admin-status-modify")]
    [Authorize]
    public async Task<IActionResult> AdminStatusModifyer([FromBody] RentalDecisionPutDto dto)
    {
        var rental = await manager.GetRentalById(dto.RentalId);
        if (rental == null) return BadRequest(new {message = "Rental not found!" });
        var beforeModifyLog = rental.RentStatus.ToString();
        var result = await manager.AdminStatusModify(dto);
        if(!result.success)
        {
            return BadRequest(new {message = $"Status change failed! {result.reason}" });
        }
        var currentStatus = rental.RentStatus.ToString();
        return Ok(new {message = $"Status change from {beforeModifyLog} " +
            $"to {currentStatus} was successful" });
    }

    [HttpGet("unavailable-periods{id}")]
    public async Task<List<UnavailablePeriodsDto>> UnavailablePeriods(int id)
    {
        return await manager.UnavailablePeriods(id);
    }
}
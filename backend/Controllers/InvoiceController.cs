using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CarRentalSystem;

[ApiController]
[Route("api/CarRental")]
public class InvoiceController: ControllerBase
{
    InvoiceManager manager;
    public InvoiceController(InvoiceManager manager)
    {
        this.manager = manager;
    }

    [HttpPost("invoice", Name = "AddInvoice")]
    [Authorize]
    [Authorize(Roles = "agent")]
    async public Task<IActionResult> AddInvoice(RentIdToInvoiceDTO dto)
    {
        int userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value); 

        bool success = await manager.AddInvoice(dto);

        if (!success)
        {
            return BadRequest(new { message = "The invoice cannot be issued." });
        }
        return Ok(new {message ="succesfull"});
    }
 
}
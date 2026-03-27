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
    async public Task<IActionResult> AddInvoice(RentIdToInvoiceDTO dto)
    {
        bool success = await manager.AddInvoice(dto);

        if (!success)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut("invoice/{id}", Name = "UpdateInvoice")]
    public async Task UpdateInvoice(int id, [FromBody] Invoice invoice)
    {
        await manager.UpdateInvoice(id, invoice);
    }
 
}
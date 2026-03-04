using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CarRentalSystem;

[ApiController]
[Route("api/CarRental")]
public class InvoiceController: ControllerBase
{
    InvoiceManagger managger;
    public InvoiceController(InvoiceManagger managger)
    {
        this.managger = managger;
    }
    [HttpGet("invoices", Name = "GetInvoices")]
    async public Task<List<Invoice>> GetInvoice()
    {
        return await managger.GetInvoice();
    }

    [HttpGet("invoice/{id}", Name = "GetInvoice")]
    async public Task<Invoice?> GetInvoiceById(int id)
    {
        return await managger.GetInvoiceById(id);
    }

    [HttpPost("invoice", Name = "AddInvoice")]
    async public Task AddInvoice(Invoice invoice)
    {
        await managger.AddInvoice(invoice);
    }

    [HttpPut("invoice/{id}", Name = "UpdateInvoice")]
    public async Task UpdateInvoice(int id, [FromBody] Invoice invoice)
    {
        await managger.UpdateInvoice(id, invoice);
    }
 
}
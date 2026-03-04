using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class InvoiceManager
{
    private readonly CarRentalDbContext context;
    public InvoiceManager(CarRentalDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Invoice>> GetInvoice()
    {
        return await context.Invoices.ToListAsync();
    }

    public async Task<Invoice?> GetInvoiceById(int id)
    {
        return await context.Invoices.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddInvoice(Invoice invoice)
    {
        await context.Invoices.AddAsync(invoice);
        await context.SaveChangesAsync();
    }

    public async Task UpdateInvoice(int id, Invoice invoice)
    {
        invoice.Id = id;
        context.Invoices.Update(invoice);
        await context.SaveChangesAsync();
    }
}
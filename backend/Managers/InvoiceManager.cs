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

    public async Task<bool> AddInvoice(RentIdToInvoiceDTO dto)
    {
        var rentalData = await context.Rentals
        .Where(r => r.Id == dto.RentId)
        .Select(r => new 
        { 
            r.StartDate,
            r.EndDate,
            r.RentStatus,
            Price = (int?)r.Car.RentPrice
        })
        .FirstOrDefaultAsync();


        if (rentalData == null)
        {
            return false;
        }
        if (rentalData.RentStatus != RentStatus.Active && rentalData.RentStatus != RentStatus.Closed)
        {
            return false;
        }
        
        int numberOfDays = (rentalData.EndDate - rentalData.StartDate).Value.Days;

        await context.Invoices.AddAsync(new Invoice
        {
            RentId = dto.RentId,
            Amount = numberOfDays * rentalData.Price ?? 0,
            IssueDate = DateTime.Now,
            PayDate = DateTime.Now
        });

        await context.SaveChangesAsync();
        return true;
    }

    public async Task UpdateInvoice(int id, Invoice invoice)
    {
        invoice.Id = id;
        context.Invoices.Update(invoice);
        await context.SaveChangesAsync();
    }
}
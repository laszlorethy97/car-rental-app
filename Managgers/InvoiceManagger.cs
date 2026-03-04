using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class InvoiceManagger
{
    private readonly CarRentalDbContext context;
    public InvoiceManagger(CarRentalDbContext context)
    {
        this.context = context;
    }
}
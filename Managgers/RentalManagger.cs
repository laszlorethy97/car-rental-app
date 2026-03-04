using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class RentalManagger
{
    private readonly CarRentalDbContext context;
    public RentalManagger(CarRentalDbContext context)
    {
        this.context = context;
    }
}
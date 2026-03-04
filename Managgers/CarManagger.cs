using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class CarManagger
{
    private readonly CarRentalDbContext context;
    public CarManagger(CarRentalDbContext context)
    {
        this.context = context;
    }

    
}
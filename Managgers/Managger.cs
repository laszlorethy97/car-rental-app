using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CarRentalSystem;

public class Managger
{
    private readonly CarRentalDbContext context;
    public Managger(CarRentalDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Car>> GetCars()
    {
        return await context.Cars.ToListAsync();
    }

    public async Task<Car?> GetCarById(int id)
    {
        return await context.Cars.FirstOrDefaultAsync(c => c.Id == id);
    }
}
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class CarManager
{
    private readonly CarRentalDbContext context;
    public CarManager(CarRentalDbContext context)
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
    public async Task AddCar(Car car)
    {
        await context.Cars.AddAsync(car);
        await context.SaveChangesAsync();
    }
    public async Task UpdateCar(int id, Car car)
    {
        car.Id = id;
        context.Cars.Update(car);
        await context.SaveChangesAsync();
    } 
}
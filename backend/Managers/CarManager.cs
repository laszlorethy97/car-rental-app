using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class CarManager
{
    private readonly CarRentalDbContext context;
    public CarManager(CarRentalDbContext context)
    {
        this.context = context;
    }

    public async Task<List<CarsGetDTO>> GetCars()
    {
        return await context.Cars.Select(c => new CarsGetDTO
        {
            Id = c.Id,
            LicensePlate = c.LicensePlate,
            Brand = c.Brand,
            Model = c.Model,
            Year = c.Year ?? 0,
            Kilometrage = c.Kilometrage ?? 0,
            RentPrice = c.RentPrice ?? 0,
            CarStatus = c.CarStatus,
            CarMaintenances = c.CarMaintenances
        }).ToListAsync();
    }
    public async Task<CarsGetDTO?> GetCarById(int id)
    {
        return await context.Cars.Select(c =>  new CarsGetDTO
        {
            Id = c.Id,
            LicensePlate = c.LicensePlate,
            Brand = c.Brand,
            Model = c.Model,
            Year = c.Year ?? 0,
            Kilometrage = c.Kilometrage ?? 0,
            RentPrice = c.RentPrice ?? 0,
            CarStatus = c.CarStatus,
            CarMaintenances = c.CarMaintenances
        }).FirstOrDefaultAsync(c => c.Id == id);
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
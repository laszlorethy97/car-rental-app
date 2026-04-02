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
            CarStatus = c.CarStatus.ToString(),
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
            CarStatus = c.CarStatus.ToString(),
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

    public async Task<(bool success, string reason)> AddMaintenance(MaintenancePostDTO dto)
    {
        if (!await context.Cars.AnyAsync(c => c.Id == dto.Id))
        {
            return (false, "No Cars with matching Id");
        }
        if (DateTime.Parse(dto.StartDate) > DateTime.Parse(dto.EndDate))
        {
            return (false, "Input correct dates");
        }

        await context.CarMaintenances.AddAsync(new CarMaintenance
        {
            CarId = dto.Id,
            StartDate = DateTime.Parse(dto.StartDate),
            EndDate = DateTime.Parse(dto.EndDate)
        });

        var overlappingRentals = await context.Rentals.
            Where(c => c.CarId == dto.Id && DateTime.Parse(dto.StartDate) < c.EndDate && c.StartDate < DateTime.Parse(dto.EndDate) && c.RentStatus != RentStatus.Rejected).ToListAsync();

        foreach (var rental in overlappingRentals)
        {
            rental.RentStatus = RentStatus.Rejected;
        }
        
        await context.SaveChangesAsync();
        return (true, "Ok");
    }
}
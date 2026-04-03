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
        }).FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<bool> AddCar(CarPostDTO carDTO)
    {
        Enum.TryParse<CarStatus>(carDTO.CarStatus, true, out var status);
        Car car = new Car
        {
            LicensePlate = carDTO.LicensePlate,
            Brand = carDTO.Brand,
            Model = carDTO.Model,
            Year = carDTO.Year,
            Kilometrage = carDTO.Kilometrage,
            RentPrice = carDTO.RentPrice,
            CarStatus = status
        };

        await context.Cars.AddAsync(car);
        await context.SaveChangesAsync();
        return true;
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

    public async Task<(bool success, string reason)> ModifyCar(CarsGetDTO dto)
    {
        var car = await context.Cars.FindAsync(dto.Id);
        if (car == null)
            return (false, $"Car:{dto.Id} not found");

        var duplicate = await context.Cars
            .AnyAsync(c => c.LicensePlate == dto.LicensePlate && c.Id != dto.Id);
        if (duplicate)
            return (false, "LicensePlate already exists");

        if (!Enum.TryParse<CarStatus>(dto.CarStatus, true, out var status)
            || !Enum.IsDefined(typeof(CarStatus), status))
            return (false, "Invalid CarStatus");

        car.LicensePlate = dto.LicensePlate;
        car.Brand = dto.Brand;
        car.Model = dto.Model;
        car.Year = dto.Year;
        car.Kilometrage = dto.Kilometrage;
        car.RentPrice = dto.RentPrice;
        car.CarStatus = status;

        await context.SaveChangesAsync();
        return (true, "Ok");
    }

    public async Task<(bool success, string reason)> DeleteCar(int id)
    {
        var car = await context.Cars
            .Include(c => c.Rentals)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (car == null)
            return (false, $"Car:{id} not found");

        var activeRentals = car.Rentals
            .Where(r =>
                   r.RentStatus == RentStatus.Active ||
                   r.RentStatus == RentStatus.Approved)
            .Select(r => r.RentStatus.ToString())
            .ToList();

        if (activeRentals.Any())
            return (false, $"Car is in {string.Join(", ", activeRentals)} status!");

        context.Rentals.RemoveRange(car.Rentals);
        context.Cars.Remove(car);

        await context.SaveChangesAsync();

        return (true, "Ok");
    }




}
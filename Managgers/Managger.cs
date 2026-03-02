using Microsoft.EntityFrameworkCore;

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

    public async Task AddCar(Car car)
    {
        await context.Cars.AddAsync(car);
        await context.SaveChangesAsync();
    }
    public async Task UpdateCarByid(int id, Car car)
    {
        Car? oldData = await context.Cars.FirstOrDefaultAsync(c => c.Id == id);
        oldData = MakeCar(oldData, car);
        await context.SaveChangesAsync();
    }
    private Car MakeCar(Car oldData, Car newData)
    {
        if(newData.Brand != null) oldData.Brand = newData.Brand;
        if(newData.CarStatus != null) oldData.CarStatus = newData.CarStatus;
        if(newData.Kilometrage != null) oldData.Kilometrage = newData.Kilometrage;
        if(newData.LicensePlate != null) oldData.LicensePlate = newData.LicensePlate;
        if(newData.Model != null) oldData.Model = newData.Model;
        if(newData.RentPrice != null) oldData.RentPrice = newData.RentPrice;
        if(newData.Year != null) oldData.Year = newData.Year;
        return oldData;        
    }

    public async Task<List<Rental>> GetRentals()
    {
        return await context.Rentals.ToListAsync();
    }

    public async Task<Rental?> GetRentalById(int id)
    {
        return await context.Rentals.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AddRental(Rental rental)
    {
        await context.Rentals.AddAsync(rental);
        await context.SaveChangesAsync();
    }
    public async Task UpdateRentalByid(int id, Rental rental)
    {
        Rental? oldData = await context.Rentals.FirstOrDefaultAsync(r => r.Id == id);
        oldData = MakeRental(oldData, rental);
        await context.SaveChangesAsync();
    }
    private Rental MakeRental(Rental oldData, Rental newData)
    {
        if(newData.StartDate != null) oldData.StartDate = newData.StartDate;
        if(newData.EndDate != null) oldData.EndDate = newData.EndDate;
        if(newData.RentStatus != null) oldData.RentStatus = newData.RentStatus;
        if(newData.ApprovedByUser != null) oldData.ApprovedByUser = newData.ApprovedByUser;
        if(newData.ApprovedByUserId != null) oldData.ApprovedByUserId = newData.ApprovedByUserId;
        return oldData;        
    }
}
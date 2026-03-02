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

    public async Task UpdateCar(int id, Car car)
    {
        car.Id = id;
        context.Cars.Update(car);
        await context.SaveChangesAsync();
    }


    /*public async Task UpdateCarByid(int id, Car car)
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
    }*/
}
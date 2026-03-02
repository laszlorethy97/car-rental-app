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
    public async Task<List<User>> GetUsers()
    {
        return await context.Users.Include(user => user.Roles).ToListAsync();
    }

    public async Task<User?> GetUserById(int id)
    {
        return await context.Users.Include(user => user.Roles).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddUser(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateUser(int id, User user)
    {
        user.Id = id;
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }


    public async Task<List<Invoice>> GetInvoice()
    {
        return await context.Invoices.ToListAsync();
    }

    public async Task<Invoice?> GetInvoiceById(int id)
    {
        return await context.Invoices.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddInvoice(Invoice invoice)
    {
        await context.Invoices.AddAsync(invoice);
        await context.SaveChangesAsync();
    }

    public async Task UpdateInvoice(int id, Invoice invoice)
    {
        invoice.Id = id;
        context.Invoices.Update(invoice);
        await context.SaveChangesAsync();
    }

}
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class Managger
{
    private readonly CarRentalDbContext context;
    public Managger(CarRentalDbContext context)
    {
        this.context = context;
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
        rental.Id = id;
        context.Rentals.Update(rental);
        await context.SaveChangesAsync();
    }

}
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class RentalManager
{
    private readonly CarRentalDbContext context;
    public RentalManager(CarRentalDbContext context)
    {
        this.context = context;
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

    public async Task<List<RentalHistoryGetDto>> GetRentalHistory()
    {
        var rentals = await context.Rentals.Include(r => r.Car).Include(r=> r.User).ToListAsync();
        return rentals.Select(r => new RentalHistoryGetDto
        {
            CarId = r.CarId,
            LicensePlate = r.Car.LicensePlate,
            Brand = r.Car.Brand,
            Model = r.Car.Model,
            StartDate = r.StartDate!.Value,
            EndDate = r.EndDate!.Value,
            RentStatus = r.RentStatus!.Value,
            RentPrice = r.Car.RentPrice!.Value
        }).ToList();
    
    }
}
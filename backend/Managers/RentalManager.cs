using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class RentalManager
{
    private readonly CarRentalDbContext context;
    public RentalManager(CarRentalDbContext context)
    {
        this.context = context;
    }

    public async Task<List<RentalGetDTO>> GetRentals()
    {
        return await context.Rentals.Include(c => c.Car).Include(u => u.User).Select(r => new RentalGetDTO
        {
            Id = r.Id,
            CarId = r.CarId,
            UserId = r.UserId,
            Brand = r.Car.Brand,
            Model = r.Car.Model,
            LicensePlate = r.Car.LicensePlate,
            UserName = r.User.UserName,
            StartDate = r.StartDate,
            EndDate = r.EndDate,
            RentStatus = r.RentStatus
        }).ToListAsync();
    }

    public async Task<Rental?> GetRentalById(int id)
    {
        return await context.Rentals.FirstOrDefaultAsync(r => r.Id == id);
    }
    
    public async Task AddRental(RentalPostDTO RPD)
    {
        await context.Rentals.AddAsync(new Rental
        {
            CarId = RPD.CarId,
            UserId = RPD.UserId,
            StartDate = RPD.StartDate,
            EndDate = RPD.EndDate,
            RentStatus = RentStatus.Requested
        });
        await context.SaveChangesAsync();
    }
    public async Task UpdateRentalByid(int id, Rental rental)
    {
        rental.Id = id;
        context.Rentals.Update(rental);
        await context.SaveChangesAsync();
    }
}
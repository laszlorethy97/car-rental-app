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
    
    public async Task<bool> AddRental(RentalPostDTO RPD, int userId)
    {
        DateTime startDate = DateTime.Parse(RPD.StartDate);
        DateTime endDate = DateTime.Parse(RPD.EndDate);

        bool inMaintenace = await context.CarMaintenances.AnyAsync(m =>
            m.CarId == RPD.CarId &&
            startDate <= m.EndDate &&
            endDate >= m.StartDate &&
            startDate < endDate &&
            startDate >= DateTime.Now
        );

        if (inMaintenace)
        {
            return false;
        }

        await context.Rentals.AddAsync(new Rental
        {
            CarId = RPD.CarId,
            UserId = userId,
            StartDate = startDate,
            EndDate = endDate,
            RentStatus = RentStatus.Requested
        });

        await context.SaveChangesAsync();
        return true;
    }
    public async Task UpdateRentalByid(int id, Rental rental)
    {
        rental.Id = id;
        context.Rentals.Update(rental);
        await context.SaveChangesAsync();
    }
}
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

//GetRentalHistoryDto
    public async Task<List<RentalHistoryGetDto>> GetRentalHistory()
    {
        var rentals = await context.Rentals.Include(r => r.Car).Include(r=> r.User).ToListAsync();
        return rentals.Select(r => new RentalHistoryGetDto
        {
            Id = r.Id,
            UserId = r.UserId,
            CarId = r.CarId,
            StartDate = r.StartDate,
            EndDate = r.EndDate,
            RentStatus = r.RentStatus,
            ApprovedByUserId = r.ApprovedByUserId,
            LicensePlate = r.Car.LicensePlate,
            Brand = r.Car.Brand,
            Model = r.Car.Model,
            Year = r.Car.Year,
            Kilometrage = r.Car.Kilometrage,
            RentPrice = r.Car.RentPrice,
            CarStatus = r.Car.CarStatus,
            Email = r.User.Email,
            UserName = r.User.UserName,
            PhoneNumber = r.User.PhoneNumber
        }).ToList();
    
    }

    //   public string? LicensePlate {get; set;}
    // public string? Brand {get; set;}
    // public string? Model {get; set;}
    // public int? Year {get; set;}
    // public int? Kilometrage {get; set;}
    // public int? RentPrice {get; set;}
    // public CarStatus CarStatus {get; set;}

    // //user details
    // public string? Email {get; set;}
    // public string? UserName {get; set;}
    // public string? PhoneNumber {get; set;}
}
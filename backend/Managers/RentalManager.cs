using Azure.Core.Pipeline;
using CarRentalSystem.DTO.RentalDTO;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class RentalManager
{
    private readonly CarRentalDbContext context;
    public RentalManager(CarRentalDbContext context)
    {
        this.context = context;
    }

    public async Task<Rental?> GetRentalById(int id)
    {
        return await context.Rentals.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<bool> AddRental(RentalPostDTO RPD, int userId)
    {
        DateTime startDate = DateTime.Parse(RPD.StartDate);
        DateTime endDate = DateTime.Parse(RPD.EndDate);

        if (startDate >= endDate)
            return false;

        if (startDate < DateTime.Now)
            return false;

        bool hasConflictRental = await context.Rentals.AnyAsync(r =>
            r.CarId == RPD.CarId &&
            startDate <= r.EndDate &&
            endDate >= r.StartDate
        );

        bool inMaintenance = await context.CarMaintenances.AnyAsync(m =>
            m.CarId == RPD.CarId &&
            startDate <= m.EndDate &&
            endDate >= m.StartDate
        );

        if (hasConflictRental || inMaintenance)
            return false;

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

    public async Task<List<RentalHistoryGetDTO>> GetRentalHistory(int userId)
    {
        var rentals = await
         context.Rentals.Include(r => r.Car)
         .Include(r => r.User)
         .Where(r => r.UserId == userId)
         .ToListAsync();

        return rentals.Select(r => new RentalHistoryGetDTO
        {
            CarId = r.CarId,
            LicensePlate = r.Car.LicensePlate,
            Brand = r.Car.Brand,
            Model = r.Car.Model,
            StartDate = r.StartDate!.Value,
            EndDate = r.EndDate!.Value,
            RentStatus = r.RentStatus!.ToString(),
            RentPrice = r.Car.RentPrice!.Value
        }).ToList();

    }

    public async Task<List<GetAllRentalsDTO>> GetAllRentals()
    {
        var rentals = await
         context.Rentals.Include(r => r.Car)
         .Include(r => r.User)
         .ToListAsync();

        return rentals.Select(r => new GetAllRentalsDTO
        {
            RentalId = r.Id,
            LicensePlate = r.Car.LicensePlate,
            Brand = r.Car.Brand,
            Model = r.Car.Model,
            StartDate = r.StartDate!.Value,
            EndDate = r.EndDate!.Value,
            RentStatus = r.RentStatus!.ToString(),
            RentPrice = r.Car.RentPrice!.Value
        }).ToList();

    }

    public async Task<(bool success, string reason)> PutRentalModify(RentalDecisionPutDto dto)
    {
        var rental = await context.Rentals.FindAsync(dto.RentalId);
        if (rental == null)
            return (false,$"Rental:{dto.RentalId} not found");
        if (rental.RentStatus != RentStatus.Requested)
            return (false,$"Not in Requested state! Current state:[{rental.RentStatus.ToString()}]");

        if (dto.Answer.ToLower() == "yes")
        {
            rental.RentStatus = RentStatus.Approved;
        }
        else if (dto.Answer.ToLower() == "no")
        {
            rental.RentStatus = RentStatus.Rejected;
        }
        else
        {
            return (false, "Only 'yes' or 'no' allowed");
        }

        await context.SaveChangesAsync();
        return (true,"Ok");
    }


    public async Task<(bool success,string reason)> CloseRental(RentalDecisionPutDto dto)
    {
        var rental = await context.Rentals.FindAsync(dto.RentalId);
        if (rental == null)
            return (false,"Rental not found");
        if (rental.RentStatus != RentStatus.Active)
            return (false,$"Not in Active state! Current state:[{rental.RentStatus}]");

        if (dto.Answer.ToLower() == "yes")
        {
            rental.RentStatus = RentStatus.Closed;
        }
        else if(dto.Answer.ToLower() == "no")
        {
            return (false, $"Not closed ");
        }
        else
        {
            return (false, $"Only 'yes' or 'no' allowed");
        }
        
        await context.SaveChangesAsync();
        return (true,"Ok");
    }



}
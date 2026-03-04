using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class UserManagger
{
    private readonly CarRentalDbContext context;
    public UserManagger(CarRentalDbContext context)
    {
        this.context = context;
    }
}
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem;

public class UserManager
{
    private readonly CarRentalDbContext context;
    public UserManager(CarRentalDbContext context)
    {
        this.context = context;
    }

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
}
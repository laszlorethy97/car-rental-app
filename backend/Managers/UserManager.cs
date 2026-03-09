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
        return await context.Users.Include(user => user.Roles).
            FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> AddUser(RegistrationUserPostDTO registrationUserPostDTO)
    {
        var exist = await ExistUser(registrationUserPostDTO);
        if(exist)
        {
            return false;
        }
        User user = await builduser(registrationUserPostDTO);
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<User> builduser(RegistrationUserPostDTO registrationUserPostDTO)
    {

        List<Role> roles = await AddRoles(registrationUserPostDTO.RoleIds.ToList());
        return new User
        {
            Email = registrationUserPostDTO.Email,
            Password = registrationUserPostDTO.Password,
            UserName = registrationUserPostDTO.UserName,
            FirstName = registrationUserPostDTO.FirstName,
            LastName = registrationUserPostDTO.LastName,
            PhoneNumber = registrationUserPostDTO.PhoneNumber,
            Address = registrationUserPostDTO.Address,
            Roles = roles
        };
    }

    public async Task<List<Role>> AddRoles(List<int> roleIds)
    {
        return await this.context.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
    }

    public async Task<bool> ExistUser(RegistrationUserPostDTO registrationUserPostDTO)
    {
        bool existUser = await context.Users
        .AnyAsync(u => u.UserName == registrationUserPostDTO.UserName
                    || u.Email == registrationUserPostDTO.Email);
        return existUser;
    }


    public async Task<bool> LoginUser(LoginUserPostDTO loginUserPostDTO)
    {
        User user = await this.context.Users.FirstOrDefaultAsync(u => u.UserName == loginUserPostDTO.UserName);
        if(user == null)
        {
            return false;
        }
        return loginUserPostDTO.Password == user.Password;
    }


    public async Task UpdateUser(int id, User user)
    {
        user.Id = id;
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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

    public async Task<EditProfileGetDTO> GetUserById(int id)
    {
        User user =  await context.Users.FirstOrDefaultAsync(c => c.Id == id);
        return new EditProfileGetDTO
        {
            Email = user.Email,
            Password = user.Password,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address
        };
    }

    public async Task<bool> Registration(RegistrationUserPostDTO registrationUserPostDTO)
    {
        bool usernameExists = await context.Users.AnyAsync(u => u.UserName == registrationUserPostDTO.UserName);
        if(usernameExists) return false;
        bool emailExist =  await context.Users.AnyAsync(u => u.Email == registrationUserPostDTO.Email);
        if(emailExist)
        {
            bool haveRole = await HaveRole(registrationUserPostDTO);
            if (haveRole)
            {
                return false;
            }
            await UpdateGuestUser(registrationUserPostDTO);
            return true;  
        }
        await AddUser(registrationUserPostDTO);
        return true;
    }

    public async Task AddUser(RegistrationUserPostDTO registrationUserPostDTO)
    {
        User user = await builduser(registrationUserPostDTO);
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }
    public async Task<bool> HaveRole(RegistrationUserPostDTO registrationUserPostDTO)
    {
        return await context.Users.Where(u => u.Email == registrationUserPostDTO.Email)
        .AnyAsync(u => u.Roles.Count > 0);
    }
    public async Task UpdateGuestUser(RegistrationUserPostDTO registrationUserPostDTO)
    {
        List<Role> roles = await AddRoles(registrationUserPostDTO.RoleIds.ToList());
        User user = await context.Users.FirstOrDefaultAsync(u => u.Email == registrationUserPostDTO.Email);
        user.UserName = registrationUserPostDTO.UserName;
        user.Password = registrationUserPostDTO.Password;
        user.FirstName = registrationUserPostDTO.FirstName;
        user.LastName = registrationUserPostDTO.LastName;
        user.PhoneNumber = registrationUserPostDTO.PhoneNumber;
        user.Address = registrationUserPostDTO.Address;
        user.Roles = roles;
        await context.SaveChangesAsync();
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

    public async Task<bool> LoginUser(LoginUserPostDTO loginUserPostDTO)
    {
        User user = await this.context.Users.FirstOrDefaultAsync(u => u.UserName == loginUserPostDTO.UserName);
        if(user == null)
        {
            return false;
        }
        return loginUserPostDTO.Password == user.Password;
    }

    public async Task<bool> UpdateGuestUser(int id, UserEditProfilePutDto dto)
    {
        User user = await context.Users.FindAsync(dto.Id);
        var FindUserByEmailAndName = await context.Users
            .FirstOrDefaultAsync(u =>
                u.Email == dto.Email &&
                u.UserName == dto.UserName);

        if (user == null)
        {
            return false;
        }
        if (dto.Email != user.Email)
            user.Email = dto.Email;
        if(dto.UserName != user.UserName)
            user.UserName = dto.UserName;

        if (dto.FirstName != null)
            user.FirstName = dto.FirstName;
        if (dto.Password != null)
            user.Password = dto.Password;
        if (dto.FirstName != null)
            user.FirstName = dto.FirstName;
        if (dto.LastName != null)
            user.LastName = dto.LastName;
        if (dto.PhoneNumber != null)
            user.PhoneNumber = dto.PhoneNumber;
        if (dto.Address != null)
            user.Address = dto.Address;

        await context.SaveChangesAsync();
        return true;
    }
}
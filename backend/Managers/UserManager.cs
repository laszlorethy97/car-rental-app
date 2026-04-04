using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace CarRentalSystem;

public class UserManager
{
    private readonly CarRentalDbContext context;
    public UserManager(CarRentalDbContext context)
    {
        this.context = context;
    }


    private string BuildToken(User user)
    {
        var key = Encoding.ASCII.GetBytes("ezEgyNagyonTitkosKulcs123!Megerkezo");
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        var claims = new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
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
        // Ha nincs megadott role ID, akkor general role-t kapjon (id = 1)
        List<int> roleIds = registrationUserPostDTO.RoleIds != null && registrationUserPostDTO.RoleIds.Count > 0
            ? registrationUserPostDTO.RoleIds.ToList()
            : new List<int> { 1 }; 

        List<Role> roles = await AddRoles(roleIds);

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

    public async Task<string?> LoginUser(LoginUserPostDTO loginUserPostDTO)
    {
        User user = await this.context.Users
            .FirstOrDefaultAsync(u => u.UserName == loginUserPostDTO.UserName);
        if (user == null || loginUserPostDTO.Password != user.Password)
        {
            return null;
        }
        string token = BuildToken(user);
        return token;
    }

    public async Task<bool> UpdateExistingUser(int id, UserEditProfilePutDto dto)
    {
        User user = await context.Users.FindAsync(id);

        if (user == null)
        {
            return false;
        }

        var emailExists = await context.Users
            .AnyAsync(u => u.Email == dto.Email && u.Id != id);
        
        if (emailExists)
        {
            return false;
        }

        var usernameExists = await context.Users
            .AnyAsync(u => u.UserName == dto.UserName && u.Id != id);

        if (usernameExists)
        {
            return false;
        }

        user.Email = dto.Email;
        user.UserName = dto.UserName;
        user.Password = dto.Password;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.PhoneNumber = dto.PhoneNumber;
        user.Address = dto.Address;

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<UserGetRolesDTO>> GetRoles(int id)
    {
        return await context.Users.Include(r => r.Roles).Where(u => u.Id == id).SelectMany(r => r.Roles).Select(r => new UserGetRolesDTO
        {
            RoleType = r.RoleType
        }).ToListAsync();
    }

    public async Task<(bool success, string reason)> GuestUserRegistration(GuestUserRegisterFromDTO dto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

        //Ellenőrzés-------------------------------------------
            DateTime startDate = DateTime.Parse(dto.StartDate);
            DateTime endDate = DateTime.Parse(dto.EndDate);

            if (startDate >= endDate)
                return (false, "Input correct dates");

            if (startDate < DateTime.Now)
                return (false, "Input correct dates");

            bool hasConflictRental = await context.Rentals.AnyAsync(r =>
                r.CarId == dto.CarId &&
                r.RentStatus != RentStatus.Rejected &&
                startDate < r.EndDate &&
                endDate > r.StartDate
            );

            bool inMaintenance = await context.CarMaintenances.AnyAsync(m =>
                m.CarId == dto.CarId &&
                startDate <= m.EndDate &&
                endDate >= m.StartDate
            );

            if (hasConflictRental || inMaintenance)
                return (false, "Date not available");

        //Ellenőrzés vége--------------------------------------

        if (user == null)
        {
            user = new User
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

        }

        await context.Rentals.AddAsync(new Rental
        {
            UserId = user.Id,
            CarId = dto.CarId,
            StartDate = DateTime.Parse(dto.StartDate),
            EndDate = DateTime.Parse(dto.EndDate),
            RentStatus = RentStatus.Requested,
        });

        await context.SaveChangesAsync();
        return (true, "success");
    }
}
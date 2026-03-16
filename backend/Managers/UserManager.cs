using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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
            await UpdateUser(registrationUserPostDTO);
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
    public async Task UpdateUser(RegistrationUserPostDTO registrationUserPostDTO)
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

    public async Task UpdateUser(int id, User user)
    {
        user.Id = id;
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }
}
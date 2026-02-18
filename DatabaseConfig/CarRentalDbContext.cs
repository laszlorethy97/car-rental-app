using Microsoft.EntityFrameworkCore;
namespace CarRentalSystem;

public class CarRentalDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Rental> Rentals { get; set; } = null!;
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CarRentalDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rental>()
        .HasOne(r => r.User)
        .WithMany(u => u.Rentals)
        .HasForeignKey(r => r.UserId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rental>()
        .HasOne(r => r.ApprovedByUser)
        .WithMany(u => u.ApprovedRentals)
        .HasForeignKey(r => r.ApprovedByUserId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rental>()
        .HasOne(r => r.Car)
        .WithMany(c => c.Rentals)
        .HasForeignKey(r => r.CarId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Invoice>()
        .HasOne(i => i.Rental)
        .WithOne()
        .HasForeignKey<Invoice>(i => i.RentId)
        .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}

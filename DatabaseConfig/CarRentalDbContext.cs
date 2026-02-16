namespace FishingShop
{
    public class FishingShopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Rental> Rentals { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Invoince> Invoinces { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FishingShopDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
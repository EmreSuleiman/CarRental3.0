using CarRental3._0.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CarRental3._0.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().Property(c => c.DailyRate).HasPrecision(18, 2);
            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalCost)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Car>().HasKey(c => c.CarId);
            modelBuilder.Entity<Booking>()
               .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            //modelBuilder.Entity<Car>().HasData(
            //    new Car
            //    {
            //        CarId = 1,
            //        Brand = "Toyota",
            //        Model = "Camry",
            //        Year = 2024,
            //        DailyRate = 30,
            //        Image = "https://global.toyota/pages/models/images/camry/camry_010_s.jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    }
            //);
            //modelBuilder.Entity<Car>().HasData(
            //    new Car()
            //    {
            //        CarId = 2,
            //        Brand = "Toyota",
            //        Model = "Camry",
            //        Year = 2020,
            //        DailyRate = 50,
            //        Status = "В наличност",
            //        Image = "https://www.cstatic-images.com/car-pictures/xl/USC90TOC021A021001.png"
            //    });
        }
    }
}

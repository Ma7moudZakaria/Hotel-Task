using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HotelEntities.Entities;

public class HotelDbContext : DbContext
{
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<Reservation> Reservation { get; set; }

    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer(new SqlConnectionStringBuilder
        //{
        //    DataSource = @".",
        //    InitialCatalog = "HotelDatabase",
        //    IntegratedSecurity = true
        //}.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Room>().HasData(
        //    new Room { Id = Guid.Parse("1903e1ee-4665-48fc-8297-c3af340caa18"), RoomNumber = 1, RoomType = "Suit", PricePerNight = 5000, Floor = 1, NumberOfBeds = 5 },
        //    new Room { Id = Guid.Parse("16b7e63d-f218-47b8-b771-18ac5fd70318"), RoomNumber = 2, RoomType = "Single Room", PricePerNight = 1500, Floor = 2, NumberOfBeds = 1 },
        //    new Room { Id = Guid.Parse("1b276976-f737-4103-87cc-ae2b2eb1b42d"), RoomNumber = 3, RoomType = "Doublt Room", PricePerNight = 3500, Floor = 3, NumberOfBeds = 2 });

        base.OnModelCreating(modelBuilder);
    }
}
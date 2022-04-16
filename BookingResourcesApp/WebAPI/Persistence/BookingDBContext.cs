using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.DataAccess;

public class BookingDBContext : DbContext
{
    public DbSet<Booking?> Bookings { get; set; }
    public DbSet<Resource> Resources { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Booking.db");
    }
}
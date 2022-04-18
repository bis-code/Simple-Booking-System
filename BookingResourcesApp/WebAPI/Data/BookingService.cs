using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess;
using WebAPI.Model;

namespace WebAPI.Data;

public class BookingService : IBookingService
{
    private readonly BookingDBContext _bookingDbContext;

    public BookingService()
    {
        _bookingDbContext = new BookingDBContext();
    }

    public async Task<IList<Booking>> GetAllBookingsAsync()
    {
        return await _bookingDbContext.Bookings.
            ToListAsync();
    }

    public async Task<Booking?> GetBookingAsync(int bookingId)
    {
        return await _bookingDbContext.Bookings.
            FirstOrDefaultAsync(b => b.Id == bookingId);   
    }

    public async Task<Booking> AddBookingAsync(Booking booking)
    {
        await _bookingDbContext.Bookings.AddAsync(booking);
        Resource resource = await _bookingDbContext.Resources.FirstAsync(r => r.ResourceId == booking.ResourceId);
        resource.Bookings.Add(booking);
        _bookingDbContext.Resources.Update(resource);
        await _bookingDbContext.SaveChangesAsync();
        return booking;
    }
    
    public async Task<Booking?> RemoveBookingAsync(int bookingId)
    {
        Booking removedBooking = _bookingDbContext.Bookings.First(b => b.Id == bookingId); 
        _bookingDbContext.Bookings.Remove(removedBooking);
        await _bookingDbContext.SaveChangesAsync();
        return removedBooking;
    }

    public async Task UpdateBookingAsync(Booking booking)
    {
        _bookingDbContext.Bookings.Update(booking);
        await _bookingDbContext.SaveChangesAsync();
    }
}
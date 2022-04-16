using WebAPI.Model;

namespace WebAPI.Data;

public interface IBookingService
{
    Task<IList<Booking>> GetAllBookingsAsync();
    Task<Booking?> GetBookingAsync(int bookingId);
    Task<Booking> AddBookingAsync(Booking booking);
    Task<Booking?> RemoveBookingAsync(int bookingId);
    Task UpdateBookingAsync(Booking booking);
}
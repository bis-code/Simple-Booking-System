using WebClient.Model;

namespace WebClient.Data;

public interface IBookingService
{
    Task<IList<Booking>> GetAllBookingsAsync();
    Task<Booking> GetBookingAsync(int bookingId);
    Task<bool> AddBookingAsync(Booking booking);
    Task<bool> RemoveBookingAsync(int bookingId);
    Task<bool> UpdateBookingAsync(Booking booking);
}
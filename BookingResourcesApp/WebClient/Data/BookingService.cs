using WebClient.Model;

namespace WebClient.Data;

public class BookingService : IBookingService
{
    public Task<IList<Booking>> GetAllBookingsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Booking?> GetBookingAsync(int bookingId)
    {
        throw new NotImplementedException();
    }

    public Task<Booking> AddBookingAsync(Booking booking)
    {
        throw new NotImplementedException();
    }

    public Task<Booking?> RemoveBookingAsync(int bookingId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBookingAsync(Booking booking)
    {
        throw new NotImplementedException();
    }
}
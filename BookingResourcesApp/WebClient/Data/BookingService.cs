using System.Text;
using System.Text.Json;
using WebClient.Model;

namespace WebClient.Data;

public class BookingService : IBookingService
{
    private string uri = "https://localhost:7263";
    private readonly HttpClient client;

    public BookingService()
    {
        client = new HttpClient();
    }
    
    public async Task<IList<Booking>> GetAllBookingsAsync()
    {
        Task<string> stringAsync = client.GetStringAsync($"{uri}/Booking");
        string message = await stringAsync;
        List<Booking> bookings = JsonSerializer.Deserialize<List<Booking>>(message);
        return bookings;
    }

    public async Task<Booking> GetBookingAsync(int bookingId)
    {
        Task<string> stringAsync = client.GetStringAsync($"{uri}/Booking/{bookingId}");
        string message = await stringAsync;
        Booking booking = JsonSerializer.Deserialize<Booking>(message);
        return booking;
    }

    public async Task<bool> AddBookingAsync(Booking booking)
    {
        string bookingAsJson = JsonSerializer.Serialize(booking);
        HttpContent content = new StringContent(bookingAsJson,
            Encoding.UTF8,
            "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Booking", content);
        return responseMessage.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveBookingAsync(int bookingId)
    {
        HttpResponseMessage responseMessage = await client.DeleteAsync($"{uri}/Booking/{bookingId}");
        return responseMessage.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateBookingAsync(Booking booking)
    {
        string bookingAsJson = JsonSerializer.Serialize(booking);
        HttpContent content = new StringContent(bookingAsJson,
            Encoding.UTF8,
            "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync($"{uri}/Booking", content);
        return responseMessage.IsSuccessStatusCode;
    }
}
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
    private readonly BookingService _bookingService;

    public BookingController(BookingService bookingService)
    {
       _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Booking>>> GetBookings()
    {
        try
        {
            IList<Booking> bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Booking>> GetBooking([FromRoute] int id)
    {
        try
        {
            Booking booking = await _bookingService.GetBookingAsync(id);
            if (booking == null)
            {
                return StatusCode(500, "Couldn't find desired booking");
            }

            return Ok(booking);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Booking>> AddBooking([FromBody] Booking booking)
    {
        try
        {
            Booking added = await _bookingService.AddBookingAsync(booking);
            return Created($"/{booking.Id}", booking);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Booking>> UpdateBooking([FromBody] Booking booking)
    {
        try
        {
            await _bookingService.UpdateBookingAsync(booking);
            return Ok(booking);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Booking>> DeleteBooking([FromRoute] int id)
    {
        try
        {
            Booking deletedBooking = await _bookingService.RemoveBookingAsync(id);
            if (deletedBooking == null)
            {
                return StatusCode(500, "Couldn't find desired booking");
            }

            return Ok(deletedBooking);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}
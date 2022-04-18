namespace WebClient.Model;

public class BookingAlreadyMadeException : Exception
{
    public BookingAlreadyMadeException()
    {
        
    }
    
    public BookingAlreadyMadeException(string message) : base(message)
    {
        
    }
}
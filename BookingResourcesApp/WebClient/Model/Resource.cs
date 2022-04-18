using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebClient.Model;

public class Resource
{
    [JsonPropertyName("resourceId")]
    public int ResourceId { get; set; }
    [Required,MaxLength(50)]
    [JsonPropertyName("name")]
    public String Name { get; set; }
    [JsonPropertyName("quantity")]
    [Required]
    public int Quantity { get; set; }
    [JsonPropertyName("bookings")]
    public ICollection<Booking> Bookings { get; set; }

    public Resource()
    {
        Bookings = new List<Booking>();
    }
}
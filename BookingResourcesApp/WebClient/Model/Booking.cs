using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebClient.Model;

public class Booking
{
    [JsonPropertyName("id")]
    [Required]
    public int Id { get; set; }
    [JsonPropertyName("dateFrom")]
    [Required]
    public DateTime DateFrom { get; set; }
    [JsonPropertyName("dateTo")]
    [Required]
    public DateTime DateTo { get; set; }
    [JsonPropertyName("bookedQuantity")]
    [Required]
    public int BookedQuantity { get; set; }
    [JsonPropertyName("resourceId")]
    public int ResourceId { get; set; }
}
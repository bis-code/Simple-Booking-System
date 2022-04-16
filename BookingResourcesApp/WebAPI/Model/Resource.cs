using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Model;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }
    [Required,MaxLength(50)]
    public String Name { get; set; }
    [Required]
    public int Quantity { get; set; }
    [ForeignKey("ResourceId")]
    public ICollection<Booking> Bookings { get; set; }
}
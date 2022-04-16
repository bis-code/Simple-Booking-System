using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model;

public class Booking
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime DateFrom { get; set; }
    [Required]
    public DateTime DateTo { get; set; }
    [Required]
    public int BookedQuantity { get; set; }
    [ForeignKey("ResourceId")]
    public int ResourceId { get; set; }
}
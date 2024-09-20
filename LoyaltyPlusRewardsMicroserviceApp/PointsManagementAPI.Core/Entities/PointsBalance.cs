using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointsAPI.Core.Entities;

public class PointsBalance
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    [Required]
    public int TotalPoints { get; set; }
    
    [Column(TypeName = "datetime2")]
    public DateTime? LastUpdated { get; set; }
    
}
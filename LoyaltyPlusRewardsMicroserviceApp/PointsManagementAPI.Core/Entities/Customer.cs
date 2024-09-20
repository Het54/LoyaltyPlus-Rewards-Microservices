using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointsAPI.Core.Entities;

public class Customer
{
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string Email { get; set; }

    
}
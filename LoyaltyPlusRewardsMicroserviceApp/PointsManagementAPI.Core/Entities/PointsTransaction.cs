using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointsAPI.Core.Entities;

public class PointsTransaction
{
    public int TransactionId { get; set; }
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    [Required]
    public int Points { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string TransactionType { get; set; }
    
    [Column(TypeName = "datetime2")]
    public DateTime? Date { get; set; }
    
    public int OrderId { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string? Description { get; set; }
    
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionHistoryAPI.Core.Entities;

public class Transaction
{
    public int Id { get; set; }
    
    [Required]
    public int CustomerId { get; set; }   // Foreign Key for Customer table
    
    public int OrderId { get; set; } 
    public Order Order { get; set; }
    
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime? TransactionDate { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string? PaymentMethod { get; set; }

    
    [Column(TypeName = "varchar(50)")]
    public string? Status { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionHistoryAPI.Core.Entities;

public class OrderItem
{
    public int Id { get; set; }  
    
    public int OrderID { get; set; } 
    public Order Order { get; set; }

    [Required]
    public int ProductID { get; set; }  // Foreign Key to Product table (if applicable)

    [Required]
    public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal UnitPrice { get; set; }
}
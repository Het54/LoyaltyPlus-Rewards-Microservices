using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionHistoryAPI.Core.Entities;

public class Order
{
    public int Id { get; set; } 

    [Required]
    public int CustomerID { get; set; }  // Foreign Key to Customer table

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime OrderDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalAmount { get; set; }
    
    
    [Column(TypeName = "varchar(255)")]
    public string? ShippingAddress { get; set; }


    [Column(TypeName = "varchar(50)")]
    public string? OrderStatus { get; set; }
}
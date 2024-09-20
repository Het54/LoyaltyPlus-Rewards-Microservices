using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionHistoryAPI.Core.Models.RequestModels;

public class OrderRequestModel
{
    [Required]
    public int CustomerID { get; set; } 

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
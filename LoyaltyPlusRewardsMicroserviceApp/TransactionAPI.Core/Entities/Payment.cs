using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionHistoryAPI.Core.Entities;

public class Payment
{
    public int Id { get; set; }
    
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime PaymentDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string PaymentMethod { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string PaymentStatus { get; set; }
}
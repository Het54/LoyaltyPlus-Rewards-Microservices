using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRegistrationAndAuthAPI.Core.Entities;

public class LoginAttempt
{
    public int Id { get; set; }
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime? AttemptDate { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string? Status { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(45)")]
    public string? IPAddress { get; set; }
}
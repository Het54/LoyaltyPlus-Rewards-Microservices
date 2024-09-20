using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRegistrationAndAuthAPI.Core.Entities;

public class Customer
{
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string FirstName { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string LastName { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string Email { get; set; }
    
    [Required]
    public string HashedPassword { get; set; } // need to implement hashing of password
    
    [Column(TypeName = "datetime2")]
    public DateTime? DateOfBirth { get; set; }
    
    [Column(TypeName = "varchar(100)")]
    public string? AddressLine1 { get; set; }
    
    [Column(TypeName = "varchar(100)")]
    public string? AddressLine2 { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string? City { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string? State { get; set; }
    
    [Required]
    public int ZipCode { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(3)")]
    public string? Country { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string PreferredStore { get; set; }
    
    [Column(TypeName = "varchar(15)")]
    public string? PhoneNumber { get; set; }
    
    [Column(TypeName = "varchar(15)")]
    public string? MobileNumber { get; set; }
    
}
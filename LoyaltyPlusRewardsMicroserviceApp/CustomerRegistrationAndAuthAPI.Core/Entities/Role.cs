using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRegistrationAndAuthAPI.Core.Entities;

public class Role
{
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string RoleName { get; set; }
}
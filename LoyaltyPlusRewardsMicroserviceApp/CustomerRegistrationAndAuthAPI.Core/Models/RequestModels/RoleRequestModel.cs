using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;

public class RoleRequestModel
{
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string RoleName { get; set; }
}
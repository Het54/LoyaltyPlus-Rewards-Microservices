using CustomerRegistrationAndAuthAPI.Core.Entities;

namespace CustomerRegistrationAndAuthAPI.Core.Models.ResponseModels;

public class CustomerRoleResponseModel
{
    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}
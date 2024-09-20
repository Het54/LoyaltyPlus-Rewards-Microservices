using CustomerRegistrationAndAuthAPI.Core.Entities;

namespace CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;

public class CustomerRoleRequestModel
{
    public int RoleId { get; set; }
    public int CustomerId { get; set; }
}
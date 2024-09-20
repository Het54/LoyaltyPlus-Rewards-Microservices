namespace CustomerRegistrationAndAuthAPI.Core.Entities;

public class CustomerRole
{
    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}
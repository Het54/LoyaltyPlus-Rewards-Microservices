using CustomerRegistrationAndAuthAPI.Core.Entities;

namespace CustomerRegistrationAndAuthAPI.Core.Interfaces.Repositories;

public interface ICustomerRoleRepositoryAsync: IRepositoryAsync<CustomerRole>
{
    Task<IEnumerable<CustomerRole>> GetAllCustomerWithRolesAsync();
}
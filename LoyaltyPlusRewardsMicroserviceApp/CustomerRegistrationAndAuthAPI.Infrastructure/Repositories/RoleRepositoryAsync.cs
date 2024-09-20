using CustomerRegistrationAndAuthAPI.Core.Entities;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Repositories;
using CustomerRegistrationAndAuthAPI.Infrastructure.Data;

namespace CustomerRegistrationAndAuthAPI.Infrastructure.Repositories;

public class RoleRepositoryAsync: BaseRepositoryAsync<Role>, IRoleRepositoryAsync
{
    public RoleRepositoryAsync(CustomerRegistrationAndAuthDbContext customerRegistrationAndAuthDbContext) : base(customerRegistrationAndAuthDbContext)
    {
    }
}
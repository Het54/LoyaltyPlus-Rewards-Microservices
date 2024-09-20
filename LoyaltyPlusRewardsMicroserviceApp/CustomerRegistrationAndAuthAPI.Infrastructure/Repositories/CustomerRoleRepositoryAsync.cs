using CustomerRegistrationAndAuthAPI.Core.Entities;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Repositories;
using CustomerRegistrationAndAuthAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistrationAndAuthAPI.Infrastructure.Repositories;

public class CustomerRoleRepositoryAsync: BaseRepositoryAsync<CustomerRole>, ICustomerRoleRepositoryAsync
{
    private readonly CustomerRegistrationAndAuthDbContext _customerRegistrationAndAuthDbContext;

    public CustomerRoleRepositoryAsync(CustomerRegistrationAndAuthDbContext customerRegistrationAndAuthDbContext) : base(customerRegistrationAndAuthDbContext)
    {
        _customerRegistrationAndAuthDbContext = customerRegistrationAndAuthDbContext;
    }

    public async Task<IEnumerable<CustomerRole>> GetAllCustomerWithRolesAsync()
    {
        return await _customerRegistrationAndAuthDbContext.Set<CustomerRole>().Include(cr => cr.Customer)
            .Include(cr => cr.Role).ToListAsync();
    }
}
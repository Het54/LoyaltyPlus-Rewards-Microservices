using CustomerRegistrationAndAuthAPI.Core.Entities;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Repositories;
using CustomerRegistrationAndAuthAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistrationAndAuthAPI.Infrastructure.Repositories;

public class CustomerRepositoryAsync: BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
{
    private readonly CustomerRegistrationAndAuthDbContext _customerRegistrationAndAuthDbContext;

    public CustomerRepositoryAsync(CustomerRegistrationAndAuthDbContext customerRegistrationAndAuthDbContext) : base(customerRegistrationAndAuthDbContext)
    {
        _customerRegistrationAndAuthDbContext = customerRegistrationAndAuthDbContext;
    }

    public async Task<int> InsertCustomerAsync(Customer entity)
    {
        await _customerRegistrationAndAuthDbContext.Set<Customer>().AddAsync(entity);
        await _customerRegistrationAndAuthDbContext.SaveChangesAsync();
        return (entity as dynamic).Id;
    }
    
}
using CustomerRegistrationAndAuthAPI.Core.Entities;

namespace CustomerRegistrationAndAuthAPI.Core.Interfaces.Repositories;

public interface ICustomerRepositoryAsync: IRepositoryAsync<Customer>
{

    Task<int> InsertCustomerAsync(Customer entity);

}
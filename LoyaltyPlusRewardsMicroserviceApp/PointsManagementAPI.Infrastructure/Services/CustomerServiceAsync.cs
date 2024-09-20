using PointsAPI.Core.Entities;
using PointsAPI.Core.Interfaces.Repositories;
using PointsAPI.Core.Interfaces.Services;

namespace PointsAPI.Infrastructure.Services;

public class CustomerServiceAsync: ICustomerServiceAsync
{
    private readonly ICustomerRepositoryAsync _customerRepositoryAsync;

    public CustomerServiceAsync(ICustomerRepositoryAsync customerRepositoryAsync)
    {
        _customerRepositoryAsync = customerRepositoryAsync;
    }
    
    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _customerRepositoryAsync.GetAllAsync();
    }

    public async Task<Customer> GetById(int id)
    {
        return await _customerRepositoryAsync.GetByIdAsync(id);
    }

    public async Task<int> Add(Customer model)
    {
        return await _customerRepositoryAsync.InsertAsync(model);
    }

    public async Task<int> DeleteById(int id)
    {
        return await _customerRepositoryAsync.DeleteByIdAsync(id);
    }

    public async Task<int> Update(Customer model)
    {
        return await _customerRepositoryAsync.UpdateAsync(model);
    }
}
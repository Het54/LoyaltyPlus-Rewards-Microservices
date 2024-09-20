using PointsAPI.Core.Entities;

namespace PointsAPI.Core.Interfaces.Services;

public interface ICustomerServiceAsync
{
    Task<IEnumerable<Customer>> GetAll();

    Task<Customer> GetById(int id);

    Task<int> Add(Customer model);

    Task<int> DeleteById(int id);

    Task<int> Update(Customer model);
}
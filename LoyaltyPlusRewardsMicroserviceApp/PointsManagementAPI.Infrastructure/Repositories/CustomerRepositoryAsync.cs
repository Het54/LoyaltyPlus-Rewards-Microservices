using PointsAPI.Core.Entities;
using PointsAPI.Core.Interfaces.Repositories;
using PointsAPI.Infrastructure.Data;

namespace PointsAPI.Infrastructure.Repositories;

public class CustomerRepositoryAsync: BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
{
    public CustomerRepositoryAsync(PointsManagementDbContext pointsManagementDbContext) : base(pointsManagementDbContext)
    {
    }
}
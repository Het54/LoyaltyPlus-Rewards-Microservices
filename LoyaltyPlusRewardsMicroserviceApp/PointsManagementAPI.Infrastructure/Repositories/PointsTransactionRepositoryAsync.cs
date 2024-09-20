using PointsAPI.Core.Entities;
using PointsAPI.Core.Interfaces.Repositories;
using PointsAPI.Infrastructure.Data;

namespace PointsAPI.Infrastructure.Repositories;

public class PointsTransactionRepositoryAsync: BaseRepositoryAsync<PointsTransaction>, IPointsTransactionRepositoryAsync
{
    public PointsTransactionRepositoryAsync(PointsManagementDbContext pointsManagementDbContext) : base(pointsManagementDbContext)
    {
    }
}
using PointsAPI.Core.Entities;
using PointsAPI.Core.Interfaces.Repositories;
using PointsAPI.Infrastructure.Data;

namespace PointsAPI.Infrastructure.Repositories;

public class PointsBalanceRepositoryAsync: BaseRepositoryAsync<PointsBalance>, IPointsBalanceRepositoryAsync
{
    public PointsBalanceRepositoryAsync(PointsManagementDbContext pointsManagementDbContext) : base(pointsManagementDbContext)
    {
    }
}
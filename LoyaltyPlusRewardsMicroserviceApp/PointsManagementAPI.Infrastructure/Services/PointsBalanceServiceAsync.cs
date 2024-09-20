using PointsAPI.Core.Entities;
using PointsAPI.Core.Interfaces.Repositories;
using PointsAPI.Core.Interfaces.Services;

namespace PointsAPI.Infrastructure.Services;

public class PointsBalanceServiceAsync: IPointsBalanceServiceAsync
{
    private readonly IPointsBalanceRepositoryAsync _pointsBalanceRepositoryAsync;

    public PointsBalanceServiceAsync(IPointsBalanceRepositoryAsync pointsBalanceRepositoryAsync)
    {
        _pointsBalanceRepositoryAsync = pointsBalanceRepositoryAsync;
    }


    public async Task<IEnumerable<PointsBalance>> GetAll()
    {
        return await _pointsBalanceRepositoryAsync.GetAllAsync();
    }

    public async Task<PointsBalance> GetById(int id)
    {
        return await _pointsBalanceRepositoryAsync.GetByIdAsync(id);
    }

    public async Task<int> Add(PointsBalance model)
    {
        return await _pointsBalanceRepositoryAsync.InsertAsync(model);
    }

    public async Task<int> DeleteById(int id)
    {
        return await _pointsBalanceRepositoryAsync.DeleteByIdAsync(id);
    }

    public async Task<int> Update(PointsBalance model)
    {
        return await _pointsBalanceRepositoryAsync.UpdateAsync(model);
    }
}
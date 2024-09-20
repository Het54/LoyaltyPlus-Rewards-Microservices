using PointsAPI.Core.Entities;
using PointsAPI.Core.Interfaces.Repositories;
using PointsAPI.Core.Interfaces.Services;

namespace PointsAPI.Infrastructure.Services;

public class PointsTransactionServiceAsync: IPointsTransactionServiceAsync
{
    private readonly IPointsTransactionRepositoryAsync _pointsTransactionRepositoryAsync;

    public PointsTransactionServiceAsync(IPointsTransactionRepositoryAsync pointsTransactionRepositoryAsync)
    {
        _pointsTransactionRepositoryAsync = pointsTransactionRepositoryAsync;
    }
    
    public async Task<IEnumerable<PointsTransaction>> GetAll()
    {
        return await _pointsTransactionRepositoryAsync.GetAllAsync();
    }

    public async Task<PointsTransaction> GetById(int id)
    {
        return await _pointsTransactionRepositoryAsync.GetByIdAsync(id);
    }

    public async Task<int> Add(PointsTransaction model)
    {
        return await _pointsTransactionRepositoryAsync.InsertAsync(model);
    }

    public async Task<int> DeleteById(int id)
    {
        return await _pointsTransactionRepositoryAsync.DeleteByIdAsync(id);
    }

    public async Task<int> Update(PointsTransaction model)
    {
        return await _pointsTransactionRepositoryAsync.UpdateAsync(model);
    }
}
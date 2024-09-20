using PointsAPI.Core.Entities;

namespace PointsAPI.Core.Interfaces.Services;

public interface IPointsTransactionServiceAsync
{
    Task<IEnumerable<PointsTransaction>> GetAll();

    Task<PointsTransaction> GetById(int id);

    Task<int> Add(PointsTransaction model);

    Task<int> DeleteById(int id);

    Task<int> Update(PointsTransaction model);
}
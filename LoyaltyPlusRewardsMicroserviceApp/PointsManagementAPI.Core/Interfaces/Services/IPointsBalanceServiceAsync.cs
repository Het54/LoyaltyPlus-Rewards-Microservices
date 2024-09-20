using PointsAPI.Core.Entities;

namespace PointsAPI.Core.Interfaces.Services;

public interface IPointsBalanceServiceAsync
{
    Task<IEnumerable<PointsBalance>> GetAll();

    Task<PointsBalance> GetById(int id);

    Task<int> Add(PointsBalance model);

    Task<int> DeleteById(int id);

    Task<int> Update(PointsBalance model);
}
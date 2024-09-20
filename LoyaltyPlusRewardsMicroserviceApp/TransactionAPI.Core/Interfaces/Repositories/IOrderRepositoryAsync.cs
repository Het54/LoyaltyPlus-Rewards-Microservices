using TransactionHistoryAPI.Core.Entities;

namespace TransactionHistoryAPI.Core.Interfaces.Repositories;

public interface IOrderRepositoryAsync: IRepositoryAsync<Order>
{
    Task<int> InsertOrderAsync(Order entity);
}
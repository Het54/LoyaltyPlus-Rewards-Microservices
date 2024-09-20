using TransactionHistoryAPI.Core.Entities;

namespace TransactionHistoryAPI.Core.Interfaces.Repositories;

public interface ITransactionRepositoryAsync: IRepositoryAsync<Transaction>
{
    Task<int> InsertTransactionAsync(Transaction entity);
}
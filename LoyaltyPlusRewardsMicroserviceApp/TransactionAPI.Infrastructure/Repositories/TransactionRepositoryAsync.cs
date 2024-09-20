using TransactionHistoryAPI.Core.Entities;
using TransactionHistoryAPI.Core.Interfaces.Repositories;
using TransactionHistoryAPI.Infrastructure.Data;

namespace TransactionHistoryAPI.Infrastructure.Repositories;

public class TransactionRepositoryAsync: BaseRepositoryAsync<Transaction>, ITransactionRepositoryAsync
{
    private readonly TransactionDbContext _transactionDbContext;

    public TransactionRepositoryAsync(TransactionDbContext transactionDbContext) : base(transactionDbContext)
    {
        _transactionDbContext = transactionDbContext;
    }

    public async Task<int> InsertTransactionAsync(Transaction entity)
    {
        await _transactionDbContext.Set<Transaction>().AddAsync(entity);
        await _transactionDbContext.SaveChangesAsync();
        return (entity as dynamic).Id;
    }
}
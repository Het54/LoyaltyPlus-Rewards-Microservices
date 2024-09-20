using TransactionHistoryAPI.Core.Entities;
using TransactionHistoryAPI.Core.Interfaces.Repositories;
using TransactionHistoryAPI.Infrastructure.Data;

namespace TransactionHistoryAPI.Infrastructure.Repositories;

public class OrderRepositoryAsync: BaseRepositoryAsync<Order>, IOrderRepositoryAsync
{
    private readonly TransactionDbContext _transactionDbContext;

    public OrderRepositoryAsync(TransactionDbContext transactionDbContext) : base(transactionDbContext)
    {
        _transactionDbContext = transactionDbContext;
    }

    public async Task<int> InsertOrderAsync(Order entity)
    {
        await _transactionDbContext.Set<Order>().AddAsync(entity);
        await _transactionDbContext.SaveChangesAsync();
        return (entity as dynamic).Id;
    }
    
}
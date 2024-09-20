using TransactionHistoryAPI.Core.Entities;
using TransactionHistoryAPI.Core.Interfaces.Repositories;
using TransactionHistoryAPI.Infrastructure.Data;

namespace TransactionHistoryAPI.Infrastructure.Repositories;

public class OrderItemRepositoryAsync: BaseRepositoryAsync<OrderItem>, IOrderItemRepositoryAsync
{
    public OrderItemRepositoryAsync(TransactionDbContext transactionDbContext) : base(transactionDbContext)
    {
    }
}
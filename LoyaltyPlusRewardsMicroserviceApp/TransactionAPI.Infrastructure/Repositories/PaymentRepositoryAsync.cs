using TransactionHistoryAPI.Core.Entities;
using TransactionHistoryAPI.Core.Interfaces.Repositories;
using TransactionHistoryAPI.Infrastructure.Data;

namespace TransactionHistoryAPI.Infrastructure.Repositories;

public class PaymentRepositoryAsync: BaseRepositoryAsync<Payment>, IPaymentRepositoryAsync
{
    public PaymentRepositoryAsync(TransactionDbContext transactionDbContext) : base(transactionDbContext)
    {
    }
}
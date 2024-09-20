using AutoMapper;
using TransactionHistoryAPI.Core.Entities;
using TransactionHistoryAPI.Core.Interfaces.Repositories;
using TransactionHistoryAPI.Core.Interfaces.Services;
using TransactionHistoryAPI.Core.Models.RequestModels;
using TransactionHistoryAPI.Core.Models.ResponseModels;

namespace TransactionHistoryAPI.Infrastructure.Services;

public class TransactionServiceAsync: ITransactionServiceAsync
{
    private readonly ITransactionRepositoryAsync _transactionRepositoryAsync;
    private readonly IMapper _mapper;

    public TransactionServiceAsync(ITransactionRepositoryAsync transactionRepositoryAsync, IMapper mapper)
    {
        _transactionRepositoryAsync = transactionRepositoryAsync;
        _mapper = mapper;
    }
    
    
    public async Task<IEnumerable<TransactionResponseModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<TransactionResponseModel>>(await _transactionRepositoryAsync.GetAllAsync());
    }

    public async Task<TransactionResponseModel> GetById(int id)
    {
        return _mapper.Map<TransactionResponseModel>(await _transactionRepositoryAsync.GetByIdAsync(id));
    }

    public async Task<int> Add(TransactionRequestModel model)
    {
        return await _transactionRepositoryAsync.InsertTransactionAsync(_mapper.Map<Transaction>(model));
    }

    public async Task<int> DeleteById(int id)
    {
        return await _transactionRepositoryAsync.DeleteByIdAsync(id);
    }

    public async Task<int> Update(int id, TransactionRequestModel model)
    {
        var transactionEntity = new Transaction()
        {
            Id = id,
            CustomerId = model.CustomerId,
            OrderId = model.OrderId,
            TransactionDate = model.TransactionDate,
            Amount = model.Amount,
            PaymentMethod = model.PaymentMethod,
            Status = model.Status
        };

        return await _transactionRepositoryAsync.UpdateAsync(transactionEntity);
    }
}
using TransactionHistoryAPI.Core.Models.RequestModels;
using TransactionHistoryAPI.Core.Models.ResponseModels;

namespace TransactionHistoryAPI.Core.Interfaces.Services;

public interface ITransactionServiceAsync
{
    Task<IEnumerable<TransactionResponseModel>> GetAll();

    Task<TransactionResponseModel> GetById(int id);

    Task<int> Add(TransactionRequestModel model);

    Task<int> DeleteById(int id);

    Task<int> Update(int id, TransactionRequestModel model);
}
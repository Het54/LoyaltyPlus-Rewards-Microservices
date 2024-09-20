using TransactionHistoryAPI.Core.Entities;
using TransactionHistoryAPI.Core.Models.RequestModels;
using TransactionHistoryAPI.Core.Models.ResponseModels;

namespace TransactionHistoryAPI.Core.Interfaces.Services;

public interface IOrderServiceAsync
{
    Task<IEnumerable<OrderResponseModel>> GetAll();

    Task<OrderResponseModel> GetById(int id);

    Task<int> Add(OrderRequestModel model);

    Task<int> DeleteById(int id);

    Task<int> Update(int id, OrderRequestModel model);
    
}
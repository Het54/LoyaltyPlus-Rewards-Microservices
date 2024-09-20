using AutoMapper;
using TransactionHistoryAPI.Core.Entities;
using TransactionHistoryAPI.Core.Interfaces.Repositories;
using TransactionHistoryAPI.Core.Interfaces.Services;
using TransactionHistoryAPI.Core.Models.RequestModels;
using TransactionHistoryAPI.Core.Models.ResponseModels;

namespace TransactionHistoryAPI.Infrastructure.Services;

public class OrderServiceAsync: IOrderServiceAsync
{
    private readonly IOrderRepositoryAsync _orderRepositoryAsync;
    private readonly IMapper _mapper;

    public OrderServiceAsync(IOrderRepositoryAsync orderRepositoryAsync, IMapper mapper)
    {
        _orderRepositoryAsync = orderRepositoryAsync;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<OrderResponseModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<OrderResponseModel>>(await _orderRepositoryAsync.GetAllAsync());
    }

    public async Task<OrderResponseModel> GetById(int id)
    {
        return _mapper.Map<OrderResponseModel>(await _orderRepositoryAsync.GetByIdAsync(id));
    }

    public async Task<int> Add(OrderRequestModel model)
    {
        return await _orderRepositoryAsync.InsertOrderAsync(_mapper.Map<Order>(model));
    }

    public async Task<int> DeleteById(int id)
    {
        return await _orderRepositoryAsync.DeleteByIdAsync(id);
    }

    public async Task<int> Update(int id, OrderRequestModel model)
    {
        var orderEntity = new Order()
        {
            Id = id,
            CustomerID = model.CustomerID,
            OrderDate = model.OrderDate,
            TotalAmount = model.TotalAmount,
            ShippingAddress = model.ShippingAddress,
            OrderStatus = model.OrderStatus
        };

        return await _orderRepositoryAsync.UpdateAsync(orderEntity);
    }
}
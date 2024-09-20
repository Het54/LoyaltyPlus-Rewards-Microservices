using AutoMapper;
using TransactionHistoryAPI.Core.Entities;
using TransactionHistoryAPI.Core.Models.RequestModels;
using TransactionHistoryAPI.Core.Models.ResponseModels;

namespace TransactionHistoryAPI.Utilities;

public class ApplicationMapper: Profile
{
    public ApplicationMapper()
    {
        CreateMap<Order, OrderRequestModel>().ReverseMap();
        CreateMap<Order, OrderResponseModel>().ReverseMap();
        CreateMap<Transaction, TransactionRequestModel>().ReverseMap();
        CreateMap<Transaction, TransactionResponseModel>().ReverseMap();
    }
}
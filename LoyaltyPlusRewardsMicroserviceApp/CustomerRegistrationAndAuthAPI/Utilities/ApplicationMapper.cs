using AutoMapper;
using CustomerRegistrationAndAuthAPI.Core.Entities;
using CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;
using CustomerRegistrationAndAuthAPI.Core.Models.ResponseModels;

namespace CustomerRegistrationAndAuthAPI.Utilities;

public class ApplicationMapper: Profile
{
    public ApplicationMapper()
    {
        CreateMap<Customer, CustomerRequestModel>().ReverseMap();
        CreateMap<Customer, CustomerResponseModel>().ReverseMap();
        CreateMap<LoginAttempt, LoginAttemptRequestModel>().ReverseMap();
        CreateMap<LoginAttempt, LoginAttemptResponseModel>().ReverseMap();
        CreateMap<Role, RoleRequestModel>().ReverseMap();
        CreateMap<Role, RoleResponseModel>().ReverseMap();
        CreateMap<CustomerRole, CustomerRoleRequestModel>().ReverseMap();
        CreateMap<CustomerRole, CustomerRoleResponseModel>().ReverseMap();
    }
}
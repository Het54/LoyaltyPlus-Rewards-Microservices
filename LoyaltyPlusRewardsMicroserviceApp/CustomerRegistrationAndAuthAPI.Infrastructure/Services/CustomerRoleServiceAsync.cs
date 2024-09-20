using AutoMapper;
using CustomerRegistrationAndAuthAPI.Core.Entities;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Repositories;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Services;
using CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;
using CustomerRegistrationAndAuthAPI.Core.Models.ResponseModels;

namespace CustomerRegistrationAndAuthAPI.Infrastructure.Services;

public class CustomerRoleServiceAsync: ICustomerRoleServiceAsync
{
    private readonly ICustomerRoleRepositoryAsync _customerRoleRepositoryAsync;
    private readonly IMapper _mapper;

    public CustomerRoleServiceAsync(ICustomerRoleRepositoryAsync customerRoleRepositoryAsync, IMapper mapper)
    {
        _customerRoleRepositoryAsync = customerRoleRepositoryAsync;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CustomerRoleResponseModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<CustomerRoleResponseModel>>(await _customerRoleRepositoryAsync.GetAllAsync());
    }

    public async Task<IEnumerable<CustomerRoleResponseModel>> GetAllCustomerWithRolesAsync()
    {
        return _mapper.Map<IEnumerable<CustomerRoleResponseModel>>(await _customerRoleRepositoryAsync.GetAllCustomerWithRolesAsync());
    }

    public async Task<int> Add(CustomerRoleRequestModel model)
    {
        return await _customerRoleRepositoryAsync.InsertAsync(_mapper.Map<CustomerRole>(model));
    }
    
}
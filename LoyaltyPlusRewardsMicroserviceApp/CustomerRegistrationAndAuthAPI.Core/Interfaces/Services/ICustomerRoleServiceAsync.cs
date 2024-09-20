
using CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;
using CustomerRegistrationAndAuthAPI.Core.Models.ResponseModels;

namespace CustomerRegistrationAndAuthAPI.Core.Interfaces.Services;

public interface ICustomerRoleServiceAsync
{
    
    Task<IEnumerable<CustomerRoleResponseModel>> GetAll();
    
    Task<IEnumerable<CustomerRoleResponseModel>> GetAllCustomerWithRolesAsync();

    Task<int> Add(CustomerRoleRequestModel model);
    
}
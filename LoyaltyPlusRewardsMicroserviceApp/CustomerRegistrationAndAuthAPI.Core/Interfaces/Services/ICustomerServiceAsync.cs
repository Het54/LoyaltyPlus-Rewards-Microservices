using CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;
using CustomerRegistrationAndAuthAPI.Core.Models.ResponseModels;

namespace CustomerRegistrationAndAuthAPI.Core.Interfaces.Services;

public interface ICustomerServiceAsync
{
    Task<IEnumerable<CustomerResponseModel>> GetAll();

    Task<CustomerResponseModel> GetById(int id);

    Task<int> Add(CustomerRequestModel model);

    Task<int> DeleteById(int id);

    Task<int> Update(int id, CustomerRequestModel model);
}
using CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;
using CustomerRegistrationAndAuthAPI.Core.Models.ResponseModels;

namespace CustomerRegistrationAndAuthAPI.Core.Interfaces.Services;

public interface IRoleServiceAsync
{
    Task<IEnumerable<RoleResponseModel>> GetAll();

    Task<RoleResponseModel> GetById(int id);

    Task<int> Add(RoleRequestModel model);

    Task<int> DeleteById(int id);

    Task<int> Update(int id, RoleRequestModel model);
}
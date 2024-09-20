using AutoMapper;
using CustomerRegistrationAndAuthAPI.Core.Entities;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Repositories;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Services;
using CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;
using CustomerRegistrationAndAuthAPI.Core.Models.ResponseModels;

namespace CustomerRegistrationAndAuthAPI.Infrastructure.Services;

public class RoleServiceAsync: IRoleServiceAsync
{
    private readonly IRoleRepositoryAsync _roleRepositoryAsync;
    private readonly IMapper _mapper;

    public RoleServiceAsync(IRoleRepositoryAsync roleRepositoryAsync, IMapper mapper)
    {
        _roleRepositoryAsync = roleRepositoryAsync;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<RoleResponseModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<RoleResponseModel>>(await _roleRepositoryAsync.GetAllAsync());
    }

    public async Task<RoleResponseModel> GetById(int id)
    {
        return _mapper.Map<RoleResponseModel>(await _roleRepositoryAsync.GetByIdAsync(id));
    }

    public async Task<int> Add(RoleRequestModel model)
    {
        return await _roleRepositoryAsync.InsertAsync(_mapper.Map<Role>(model));
    }

    public async Task<int> DeleteById(int id)
    {
        return await _roleRepositoryAsync.DeleteByIdAsync(id);
    }

    public async Task<int> Update(int id, RoleRequestModel model)
    {
        var roleEntity = new Role()
        {
            Id = id,
            RoleName = model.RoleName
        };

        return await _roleRepositoryAsync.UpdateAsync(roleEntity);
    }
}
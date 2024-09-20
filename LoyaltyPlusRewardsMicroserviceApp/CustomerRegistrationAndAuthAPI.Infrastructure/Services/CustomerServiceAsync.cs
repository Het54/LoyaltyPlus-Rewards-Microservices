using AutoMapper;
using Azure.Messaging.ServiceBus;
using CustomerRegistrationAndAuthAPI.Core.Entities;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Repositories;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Services;
using CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;
using CustomerRegistrationAndAuthAPI.Core.Models.ResponseModels;
using Microsoft.Extensions.Configuration;

namespace CustomerRegistrationAndAuthAPI.Infrastructure.Services;

public class CustomerServiceAsync: ICustomerServiceAsync
{
    private readonly ICustomerRepositoryAsync _customerRepositoryAsync;
    private readonly IMapper _mapper;
    private readonly ICustomerRoleServiceAsync _customerRoleServiceAsync;
    private readonly ServiceBusClient _serviceBusClient;
    private readonly IConfiguration _configuration;
    private readonly string? _topicName;

    public CustomerServiceAsync(ICustomerRepositoryAsync customerRepositoryAsync, IMapper mapper, ICustomerRoleServiceAsync customerRoleServiceAsync, ServiceBusClient serviceBusClient, IConfiguration configuration)
    {
        _customerRepositoryAsync = customerRepositoryAsync;
        _mapper = mapper;
        _customerRoleServiceAsync = customerRoleServiceAsync;
        _serviceBusClient = serviceBusClient;
        _configuration = configuration;
        _topicName = configuration.GetSection("AzureServiceBus:TopicName").Value;
    }
    
    public async Task<IEnumerable<CustomerResponseModel>> GetAll()
    {

        return _mapper.Map<IEnumerable<CustomerResponseModel>>(await _customerRepositoryAsync.GetAllAsync());

    }

    public async Task<CustomerResponseModel> GetById(int id)
    {
        return _mapper.Map<CustomerResponseModel>(await _customerRepositoryAsync.GetByIdAsync(id));
    }

    public async Task<int> Add(CustomerRequestModel model)
    {
        var id = await _customerRepositoryAsync.InsertCustomerAsync(_mapper.Map<Customer>(model));
        CustomerRoleRequestModel customerRoleRequestModel = new CustomerRoleRequestModel
        {
            RoleId = 2,
            CustomerId = id
        };

        await _customerRoleServiceAsync.Add(customerRoleRequestModel);

        ServiceBusSender sender = _serviceBusClient.CreateSender(_topicName);
        var message = new ServiceBusMessage($"New Customer Added: {id}")
        {
            CorrelationId = "TransactionService",
        };
        await sender.SendMessageAsync(message);
        
        return id;
        
    }

    public async Task<int> DeleteById(int id)
    {
        return await _customerRepositoryAsync.DeleteByIdAsync(id);
    }

    public async Task<int> Update(int id, CustomerRequestModel model)
    {
        var customerEntity = new Customer()
        {
            Id = id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            HashedPassword = model.HashedPassword,
            DateOfBirth = model.DateOfBirth,
            AddressLine1 = model.AddressLine1,
            AddressLine2 = model.AddressLine2,
            City = model.City,
            State = model.State,
            ZipCode = model.ZipCode,
            Country = model.Country,
            PreferredStore = model.PreferredStore,
            PhoneNumber = model.PhoneNumber,
            MobileNumber = model.MobileNumber
        };

        return await _customerRepositoryAsync.UpdateAsync(customerEntity);
    }
    
}
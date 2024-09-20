using CustomerRegistrationAndAuthAPI.Core.Entities;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Repositories;
using CustomerRegistrationAndAuthAPI.Infrastructure.Data;

namespace CustomerRegistrationAndAuthAPI.Infrastructure.Repositories;

public class LoginAttemptRepositoryAsync: BaseRepositoryAsync<LoginAttempt>, ILoginAttemptRepositoryAsync
{
    public LoginAttemptRepositoryAsync(CustomerRegistrationAndAuthDbContext customerRegistrationAndAuthDbContext) : base(customerRegistrationAndAuthDbContext)
    {
    }
}
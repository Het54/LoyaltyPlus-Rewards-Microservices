using CustomerRegistrationAndAuthAPI.Core.Interfaces.Repositories;
using CustomerRegistrationAndAuthAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistrationAndAuthAPI.Infrastructure.Repositories;

public class BaseRepositoryAsync<T>: IRepositoryAsync<T> where T: class
{
    private readonly CustomerRegistrationAndAuthDbContext _customerRegistrationAndAuthDbContext;

    public BaseRepositoryAsync(CustomerRegistrationAndAuthDbContext customerRegistrationAndAuthDbContext)
    {
        _customerRegistrationAndAuthDbContext = customerRegistrationAndAuthDbContext;
    }
    
    
    public async Task<int> InsertAsync(T entity)
    {
        await _customerRegistrationAndAuthDbContext.Set<T>().AddAsync(entity);
        return await _customerRegistrationAndAuthDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _customerRegistrationAndAuthDbContext.Entry(entity).State = EntityState.Modified;
        return await _customerRegistrationAndAuthDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);

        if (entity != null)
        {
            _customerRegistrationAndAuthDbContext.Set<T>().Remove(entity);
            return await _customerRegistrationAndAuthDbContext.SaveChangesAsync();
        }

        return 0;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _customerRegistrationAndAuthDbContext.Set<T>().FindAsync(id) ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _customerRegistrationAndAuthDbContext.Set<T>().ToListAsync();
    }
}
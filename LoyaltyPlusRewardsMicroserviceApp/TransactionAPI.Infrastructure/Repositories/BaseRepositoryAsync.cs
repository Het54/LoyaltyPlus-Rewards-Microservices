using Microsoft.EntityFrameworkCore;
using TransactionHistoryAPI.Core.Interfaces.Repositories;
using TransactionHistoryAPI.Infrastructure.Data;

namespace TransactionHistoryAPI.Infrastructure.Repositories;

public class BaseRepositoryAsync<T>: IRepositoryAsync<T> where T: class
{
    private readonly TransactionDbContext _transactionDbContext;

    public BaseRepositoryAsync(TransactionDbContext transactionDbContext)
    {
        _transactionDbContext = transactionDbContext;
    }
    
    
    public async Task<int> InsertAsync(T entity)
    {
        await _transactionDbContext.Set<T>().AddAsync(entity);
        return await _transactionDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _transactionDbContext.Entry(entity).State = EntityState.Modified;
        return await _transactionDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);

        if (entity != null)
        {
            _transactionDbContext.Set<T>().Remove(entity);
            return await _transactionDbContext.SaveChangesAsync();
        }

        return 0;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _transactionDbContext.Set<T>().FindAsync(id) ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _transactionDbContext.Set<T>().ToListAsync();
    }
}
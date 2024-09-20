using Microsoft.EntityFrameworkCore;
using PointsAPI.Core.Interfaces.Repositories;
using PointsAPI.Infrastructure.Data;

namespace PointsAPI.Infrastructure.Repositories;

public class BaseRepositoryAsync<T>: IRepositoryAsync<T> where T: class
{
    private readonly PointsManagementDbContext _pointsManagementDbContext;

    public BaseRepositoryAsync(PointsManagementDbContext pointsManagementDbContext)
    {
        _pointsManagementDbContext = pointsManagementDbContext;
    }
    
    public async Task<int> InsertAsync(T entity)
    {
        await _pointsManagementDbContext.Set<T>().AddAsync(entity);
        return await _pointsManagementDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _pointsManagementDbContext.Entry(entity).State = EntityState.Modified;
        return await _pointsManagementDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);

        if (entity != null)
        {
            _pointsManagementDbContext.Set<T>().Remove(entity);
            return await _pointsManagementDbContext.SaveChangesAsync();
        }

        return 0;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _pointsManagementDbContext.Set<T>().FindAsync(id) ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _pointsManagementDbContext.Set<T>().ToListAsync();
    }
}
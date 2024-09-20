namespace TransactionHistoryAPI.Core.Interfaces.Repositories;

public interface IRepositoryAsync<T> where T: class
{
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteByIdAsync(int id);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}
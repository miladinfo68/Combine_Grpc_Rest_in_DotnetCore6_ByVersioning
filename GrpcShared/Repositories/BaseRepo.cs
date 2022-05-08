using System.Linq.Expressions;

namespace GrpcShared.Repositories;
public interface IBaseRepo
{
}

public interface IMongoBaseRepo<T> : IBaseRepo where T : class
{
    // Task<IEnumerable<T>> GetAllAsync();
    // Task<T> GetByIdAsync(string objectId);
    // Task<string> AddAsync(T entity);
    // Task<bool> UpdateAsync(string objectId, T entity);
    // Task<bool> DeleteAsync(string objectId);

    Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
    Task<T> GetByAsync(Expression<Func<T, bool>> filter);
    Task<T> GetByIdAsync(string id);
    Task<string> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(string id);
}


public interface ISqlBaseRepo<T> : IBaseRepo where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(long id);
    Task<long> AddAsync(T entity);
    Task<bool> UpdateAsync( T entity);
    Task<bool> DeleteAsync(long id);
}
namespace GrpcShared.Services;

public interface IBaseSVC { }
public interface IBaseService<Q, Y, Z> : IBaseSVC
    where Q : class
    where Y : class
    where Z : class
{
    Task<IReadOnlyCollection<Q>> GetAllAsync();
    Task<Q> GetByIdAsync(string id);
    Task<string> AddAsync(Y entity);
    Task<bool> UpdateAsync(Z entity);
    Task<bool> DeleteAsync(string id);
}
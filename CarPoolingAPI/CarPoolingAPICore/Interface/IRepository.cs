namespace CarPoolingAPICore.Interface;

public interface IRepository<in TId, T> : IDisposable, IAsyncDisposable
{
    Task<IEnumerable<T>> GetAll(int maxCount = int.MaxValue);
    Task<T> GetById(TId id);
    Task<T> GetFirstByPredicate(Func<T, bool> predicate);
    
    Task<T> Add(T entity);
    
    Task<T> Update(T entity);
    
    Task DeleteById(TId id);
}
namespace CarPoolingAPICore.Interface;

public interface IRepository<in TId, T> : IDisposable, IAsyncDisposable
{
    Task<IList<T>> GetAll(int maxCount = int.MaxValue);
    Task<T> GetById(TId id);
    Task<T> GetFirstByPredicate(Func<T, bool> predicate);
    
    Task Add(T entity);
    
    Task Update(T entity);
    
    Task DeleteById(TId id);
}
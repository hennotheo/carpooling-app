namespace CarPoolingAPICore.Interface;

public interface IRepository<in TId, T>
{
    Task<IList<T>> GetAll();
    Task<T> GetById(TId id);
    Task<T> GetFirstByPredicate(Func<T, bool> predicate);
    
    Task Add(T entity);
    
    Task Update(T entity);
    
    Task DeleteById(TId id);
}
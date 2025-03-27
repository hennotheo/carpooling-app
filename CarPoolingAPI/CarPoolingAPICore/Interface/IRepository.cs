namespace CarPoolingAPICore.Interface;

public interface IRepository<in TId, T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(TId id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(TId id);
}
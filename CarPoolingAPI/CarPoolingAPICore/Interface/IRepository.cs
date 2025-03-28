namespace CarPoolingAPICore.Interface;

public interface IRepository<in TId, T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(TId id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(TId id);
}
namespace CarPoolingAPICore.Interface;

public interface IRepository<in TId, T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(TId id);
    void Add(T entity);
    void Update(T entity);
    void Delete(TId id);
}
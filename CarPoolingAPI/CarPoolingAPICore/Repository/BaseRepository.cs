using CarPoolingAPICore.Interface;

namespace CarPoolingAPICore.Repository;

public class BaseRepository<TId, T> : IRepository<TId, T>
{
    private List<T> _entities;

    public BaseRepository()
    {
        _entities = new List<T>();
    }

    public Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<T> Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> Delete(TId id)
    {
        throw new NotImplementedException();
    }
}
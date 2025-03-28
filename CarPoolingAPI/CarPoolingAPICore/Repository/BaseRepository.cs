using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;

namespace CarPoolingAPICore.Repository;

public class BaseRepository<TId, T> : IRepository<TId, T>
{
    private List<T> _entities;//TODO: Change the variable
    
    protected virtual IEnumerable<T> Entities => _entities;

    public BaseRepository()
    {
        _entities = new List<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Task.Run(() => Entities.AsEnumerable());
    }

    public async Task<T?> GetById(TId id)
    {
        T? value = await Task.Run(() => Entities
            .FirstOrDefault(e => e.GetType().GetProperty("Id").GetValue(e).Equals(id)));

        if (object.Equals(value, default(T)))
            throw new UserNotFoundException();

        return value;
    }

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(TId id)
    {
        throw new NotImplementedException();
    }
}
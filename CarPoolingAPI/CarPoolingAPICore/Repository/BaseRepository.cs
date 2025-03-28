using System.Reflection;
using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Extensions;
using CarPoolingAPICore.Interface;

namespace CarPoolingAPICore.Repository;

public class BaseRepository<TId, T> : IRepository<TId, T>
{
    private List<T> _entities; //TODO: Change the variable

    private readonly PropertyInfo _idProp;

    protected virtual IList<T> Entities => _entities;

    public BaseRepository()
    {
        _entities = new List<T>();

        _idProp = typeof(T).GetProperty("Id")!;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Task.Run(() => Entities.AsEnumerable());
    }

    public async Task<T> GetById(TId id)
    {
        T? value = await Task.Run(() => Entities
            .FirstOrDefault(entity => _idProp.PropertyEquals(entity, id)));

        if (Equals(value, default(T)))
            throw new RepoDataNotFoundException();

        return value!;
    }

    public async Task Add(T entity)
    {
        await Task.Run(() => Entities.Add(entity));
    }

    public async Task Update(T entity)
    {
        TId id = (TId)_idProp.GetValue(entity);

        await Delete(id);
        await Add(entity);
        
        Console.WriteLine("Warning: Entity with the same ID is being updated.");
    }

    public async Task Delete(TId id)
    {
        T entity = await GetById(id);

        await Task.Run(() => Entities.Remove(entity));
    }
}
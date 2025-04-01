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

    public async Task<IList<T>> GetAll(int maxCount = int.MaxValue)
    {
        return await Task.Run(() => Entities.Take(maxCount).ToList());
    }

    public async Task<T> GetById(TId id)
    {
        return await GetFirstByPredicate(entity => _idProp.PropertyEquals(entity, id));
    }

    public async Task<T> GetFirstByPredicate(Func<T, bool> predicate)
    {
        T? value = await Task.Run(() => Entities
            .FirstOrDefault(predicate));

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
        TId id = (TId)_idProp.GetValue(entity); //TODO Change when implementing EFCore

        await DeleteById(id);
        await Add(entity);
    }

    public async Task DeleteById(TId id)
    {
        try
        {
            T entity = await GetById(id);

            Entities.Remove(entity);
        }
        catch (Exception e)
        {
            throw new RepoDataNotFoundException();
        }
    }

    public void Dispose()
    {
    }

    public async ValueTask DisposeAsync()
    {
    }
}
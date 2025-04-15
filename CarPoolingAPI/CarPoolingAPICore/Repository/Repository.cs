using System.Reflection;
using CarPoolingAPICore.Data;
using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Extensions;
using CarPoolingAPICore.Interface;
using Microsoft.EntityFrameworkCore;

namespace CarPoolingAPICore.Repository;

public class Repository<TId, T> : IRepository<TId, T> where T : class
{
    private DbContext _context;
    private DbSet<T> _entities;

    private readonly PropertyInfo _idProp;

    public Repository(ApplicationDbContext context)
    {
        Type type = typeof(T);
        if (type.GetProperty("Id") == null)
            throw new ArgumentException($"Type {type.Name} does not have an Id property.");

        // MemberInfo member = typeof(ApplicationDbContext)
        //     .GetMembers(BindingFlags.Public | BindingFlags.Instance)
        //     .First((member) => member.ReflectedType == typeof(DbSet<T>));

        _entities = context.Set<T>();
        _context = context;

        _idProp = typeof(T).GetProperty("Id")!;
    }

    public async Task<IEnumerable<T>> GetAll(int maxCount = int.MaxValue)
    {
        return await Task.FromResult(_entities.Take(maxCount));
    }

    public async Task<T> GetById(TId id)
    {
        return await GetFirstByPredicate(entity => _idProp.PropertyEquals(entity, id));
    }

    public async Task<T> GetFirstByPredicate(Func<T, bool> predicate)
    {
        T? value = await Task.Run(() => _entities
            .FirstOrDefault(predicate));

        if (Equals(value, default(T)))
            throw new RepoDataNotFoundException();

        return value!;
    }

    public async Task<T> Add(T entity)
    {
        _entities.Add(entity);

        return await Task.FromResult(entity);
    }

    public async Task<T> Update(T entity)
    {
        TId? id = (TId?)_idProp.GetValue(entity);

        if (id == null)
            throw new RepoDataNotFoundException();

        T? existingEntity = await GetById(id);

        if (existingEntity == null)
            throw new RepoDataNotFoundException();

        await Task.Run(() => { _context.Entry(entity).State = EntityState.Modified; });
        return entity;
    }

    public async Task DeleteById(TId id)
    {
        try
        {
            T entity = await GetById(id);

            _entities.Remove(entity);
        }
        catch (Exception e)
        {
            throw new RepoDataNotFoundException();
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
    }

    public async ValueTask DisposeAsync()
    {
    }
}
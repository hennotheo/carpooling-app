using CarPoolingAPICore.Interface;

namespace CarPoolingAPICore.Repository;

public class BaseRepository<T> : IRepository<T>
{
    public BaseRepository()
    {
        throw new NotImplementedException();
    }
    
    public Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(int id)
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

    public Task<T> Delete(int id)
    {
        throw new NotImplementedException();
    }
}
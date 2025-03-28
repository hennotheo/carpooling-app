using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using CarPoolingAPICore.Repository;

namespace CarPoolingAPI.Services;

public class UserService : IUserService
{
    private IRepository<int, User> _userRepository;

    private class FakeRepo : BaseRepository<int, User>
    {
        public FakeRepo() : base()
        {
            Entities.Add(new User { Id = 1, Name = "John" });
            Entities.Add(new User { Id = 2, Name = "Jane" });
        }
    }
    
    public UserService()
    {
        _userRepository = new FakeRepo();
    }
    
    public IList<User>? GetAllUsers()
    {
        return _userRepository.GetAll().Result;
    }

    public void Dispose()
    {
        _userRepository.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _userRepository.DisposeAsync();
    }
}
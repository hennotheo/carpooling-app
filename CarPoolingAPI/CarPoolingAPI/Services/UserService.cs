using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using CarPoolingAPICore.Repository;

namespace CarPoolingAPI.Services;

public class UserService : IUserService
{
    private IRepository<int, UserController> _userRepository;

    private class FakeRepo : BaseRepository<int, UserController>
    {
        public FakeRepo() : base()
        {
            Entities.Add(new UserController { Id = 1, Name = "John" });
            Entities.Add(new UserController { Id = 2, Name = "Jane" });
        }
    }
    
    public UserService()
    {
        _userRepository = new FakeRepo();
    }
    
    public IList<UserController>? GetAllUsers()
    {
        return _userRepository.GetAll().Result;
    }
}
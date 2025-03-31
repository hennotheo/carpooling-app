using CarPoolingAPI.Services;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using Moq;

namespace Tests_CarPoolingAPI;

public abstract class UserServiceTests
{
    protected UserService _service;
    protected Mock<IRepository<int, User>> _mockUserRepo;
    
    protected List<User> _data = new List<User>
    {
        new User { Id = 1, Name = "John" },
        new User { Id = 2, Name = "Jane" }
    };
    
    [SetUp]
    public void Setup()
    {
        _mockUserRepo = new Mock<IRepository<int, User>>();
        _service = new UserService();
    }

    [TearDown]
    public void TearDown()
    {
        _service.Dispose();
    }
}
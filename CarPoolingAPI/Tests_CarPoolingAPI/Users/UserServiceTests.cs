using CarPoolingAPI.DTO;
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
        new User { Id = 1, FirstName = "John" },
        new User { Id = 2, FirstName = "Jane" }
    };
    
    [SetUp]
    public virtual void Setup()
    {
        _mockUserRepo = new Mock<IRepository<int, User>>();
        _service = new UserService(_mockUserRepo.Object);
    }

    [TearDown]
    public virtual void TearDown()
    {
        _service.Dispose();
    }
}
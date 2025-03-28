using CarPoolingAPI.Services;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Get")]
public class UserServiceTests_Get
{
    private UserService _service;
    private Mock<IRepository<int, User>> _mockUserRepo;

    private List<User> _data = new List<User>
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

    [Test]
    public void GetAllUsers_NoThrow()
    {
        _mockUserRepo.Setup(repo => repo.GetAll()).ReturnsAsync(_data);

        Assert.DoesNotThrow(() => _service.GetAllUsers());
    }

    [Test]
    public void GetUsers_ReturnNonNullListOfUsers()
    {
        _mockUserRepo.Setup(repo => repo.GetAll()).ReturnsAsync(_data);

        var result = _service.GetAllUsers();
        Assert.That(result, Is.Not.Null);
    }
}
using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Repository;
using Moq;

namespace Tests_CarPoolingAPICore;

internal class UserTestData
{
    public int Id { get; set; }
    public string Name { get; set; }
}

internal class TestRepository<T> : BaseRepository<int, T>
{
    private readonly List<T> _userTestData;

    protected override IEnumerable<T> Entities => _userTestData;

    public TestRepository(T[]? data = null)
    {
        _userTestData = data != null ? [..data] : [];
    }
}

public class CarPoolingApiCoreTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateUserRepository()
    {
        Assert.DoesNotThrow(() =>
        {
            IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>();
        });
    }

    [Test]
    public void GetAllUsersThrow()
    {
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>();
        Assert.DoesNotThrowAsync(async () =>
        {
            var users = await userRepository.GetAll();
        });
    }

    [Test]
    [TestCase(1, false)]
    [TestCase(2, true)]
    public void GetUsersByIdThrow(int id, bool mustThrow)
    {
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>([new UserTestData {Id = 1, Name = "Test"}]);
        
        if (mustThrow)
        {
            Assert.ThrowsAsync<UserNotFoundException>(async () =>
            {
                var user = await userRepository.GetById(id);
            });
        }
        else
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                var user = await userRepository.GetById(id);
            });
        }
    }
}
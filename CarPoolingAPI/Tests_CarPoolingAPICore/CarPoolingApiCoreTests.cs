using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Repository;

namespace Tests_CarPoolingAPICore;

internal class UserTestData
{
    public int Id { get; set; }
    public string Name { get; set; }
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
            IRepository<int, UserTestData> userRepository = new BaseRepository<int, UserTestData>();
        });
    }

    [Test]
    public void GetAllUsers()
    {
        IRepository<int, UserTestData> userRepository = new BaseRepository<int, UserTestData>();
        Assert.DoesNotThrowAsync(async () =>
        {
            var users = await userRepository.GetAll();
        });
    }

    [Test]
    [TestCase(1, false)]
    [TestCase(2, true)]
    public void GetUsersById(int id, bool mustThrow)
    {
        IRepository<int, UserTestData> userRepository = new BaseRepository<int, UserTestData>();
        if (mustThrow)
        {
            Assert.ThrowsAsync<CarpoolingAPICoreException>(async () =>
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
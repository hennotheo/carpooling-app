using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Repository;

namespace Tests_CarPoolingAPICore;

internal class UserTest
{
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
            IRepository<UserTest> userRepository = new BaseRepository<UserTest>();
        });
    }
}
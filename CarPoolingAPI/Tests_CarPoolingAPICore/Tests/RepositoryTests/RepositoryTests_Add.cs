using CarPoolingAPICore.Interface;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_POST)]
public class RepositoryTests_Add
{
    [Test]
    public static void AddNoThrow()
    {
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>();
        Assert.DoesNotThrowAsync(async () => { await userRepository.Add(new UserTestData()); });
    }

    [Test]
    [TestCase(1, "Test")]
    [TestCase(3, "Test2")]
    public static void AddAndGetIt(int id, string name)
    {
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>();
        UserTestData user = new UserTestData()
        {
            Id = id, Name = name
        };
        userRepository.Add(user);

        Assert.That(userRepository.GetById(id).GetAwaiter().GetResult().Name, Is.EqualTo(name));
    }
}
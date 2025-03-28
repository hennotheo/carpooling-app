using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_DELETE)]
public class RepositoryTests_Delete
{
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public static void DeleteNoThrow(int id)
    {
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>([new UserTestData { Id = id, Name = "Test" }]);

        Assert.DoesNotThrowAsync(async () => { await userRepository.Delete(id); });
    }
    
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public static void DeleteThrow(int id)
    {
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>([new UserTestData { Id = id, Name = "Test" }]);

        Assert.ThrowsAsync<RepoDataNotFoundException>(async () => { await userRepository.Delete(id + 1); });//Add one to fail delete
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public static void DeleteHasBeenDeleted(int id)
    {
        UserTestData user = new UserTestData { Id = id, Name = "Test" };
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>([user]);

        userRepository.Delete(id + 1).GetAwaiter();

        Assert.ThrowsAsync<RepoDataNotFoundException>(async () => { await userRepository.GetById(id); });
    }
}
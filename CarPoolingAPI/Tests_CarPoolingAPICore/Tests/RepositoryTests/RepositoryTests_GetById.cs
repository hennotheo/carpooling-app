using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_GET)]
public class RepositoryTests_GetById
{
    [Test]
    [TestCase(1, false)]
    [TestCase(1, true)]
    [TestCase(2, true)]
    [TestCase(2, false)]
    public static void GetUsersByIdThrow(int id, bool mustThrow)
    {
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>([new UserTestData { Id = mustThrow ? id + 1 : id, Name = "Test" }]);

        if (mustThrow)
        {
            Assert.ThrowsAsync<RepoDataNotFoundException>(async () =>
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

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public static void GetUsersByIdValid(int id)
    {
        UserTestData user = new UserTestData { Id = id, Name = "Test" };
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>([user]);

        UserTestData get = userRepository.GetById(user.Id).GetAwaiter().GetResult();

        Assert.That(get.Name, Is.EqualTo(user.Name));
    }
}
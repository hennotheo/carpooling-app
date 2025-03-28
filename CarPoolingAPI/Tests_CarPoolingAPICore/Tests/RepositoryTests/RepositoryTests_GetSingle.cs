using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_GET)]
public class RepositoryTests_GetSingle
{
    [Test]
    [TestCase(1, false)]
    [TestCase(1, true)]
    [TestCase(2, true)]
    [TestCase(2, false)]
    public static void GetByIdThrow(int id, bool mustThrow)
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
    
    [Test]
    [TestCase("A", false)]
    [TestCase("A", true)]
    [TestCase("B", false)]
    [TestCase("B", true)]
    public static void GetByPredicateThrow(string name, bool mustThrow)
    {
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>([new UserTestData { Id = 1, Name = mustThrow ? name + "dd" : name }]);

        if (mustThrow)
        {
            Assert.ThrowsAsync<RepoDataNotFoundException>(async () =>
            {
                var user = await userRepository.GetFirstByPredicate(u => u.Name == name);
            });
        }
        else
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                var user = await userRepository.GetFirstByPredicate(u => u.Name == name);
            });
        }
    }

    [Test]
    [TestCase("A")]
    [TestCase("B")]
    public static async Task GetByPredicateValid(string name)
    {
        UserTestData user = new UserTestData { Id = 0, Name = name };
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>([user]);

        UserTestData get = await userRepository.GetFirstByPredicate(u => u.Name == name);

        Assert.That(get.Id, Is.EqualTo(user.Id));
    }
}
using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_GET)]
public class RepositoryTests_GetSingle : RepositoryTests
{
    [Test]
    [TestCase(1, false)]
    [TestCase(1, true)]
    [TestCase(2, true)]
    [TestCase(2, false)]
    public void GetByIdThrow(int id, bool mustThrow)
    {
        IRepository<int, UserTestModel> userRepository = SetDataInRepo([new UserTestModel { Id = mustThrow ? id + 1 : id, FirstName = "Test" }]);

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
    public void GetUsersByIdValid(int id)
    {
        UserTestModel user = new UserTestModel { Id = id, FirstName = "Test" };
        IRepository<int, UserTestModel> userRepository = SetDataInRepo([user]);

        UserTestModel get = userRepository.GetById(user.Id).GetAwaiter().GetResult();

        Assert.That(get.FirstName, Is.EqualTo(user.FirstName));
    }
    
    [Test]
    [TestCase("A", false)]
    [TestCase("A", true)]
    [TestCase("B", false)]
    [TestCase("B", true)]
    public void GetByPredicateThrow(string name, bool mustThrow)
    {
        IRepository<int, UserTestModel> userRepository = SetDataInRepo([new UserTestModel { Id = 1, FirstName = mustThrow ? name + "dd" : name }]);

        if (mustThrow)
        {
            Assert.ThrowsAsync<RepoDataNotFoundException>(async () =>
            {
                var user = await userRepository.GetFirstByPredicate(u => u.FirstName == name);
            });
        }
        else
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                var user = await userRepository.GetFirstByPredicate(u => u.FirstName == name);
            });
        }
    }

    [Test]
    [TestCase("A")]
    [TestCase("B")]
    public async Task GetByPredicateValid(string name)
    {
        UserTestModel user = new UserTestModel { Id = 0, FirstName = name };
        IRepository<int, UserTestModel> userRepository = SetDataInRepo([user]);

        UserTestModel get = await userRepository.GetFirstByPredicate(u => u.FirstName == name);

        Assert.That(get.Id, Is.EqualTo(user.Id));
    }
}
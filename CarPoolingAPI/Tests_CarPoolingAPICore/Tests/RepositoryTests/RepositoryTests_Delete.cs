using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_DELETE)]
public class RepositoryTests_Delete : RepositoryTests
{
    [Test]
    public void DeleteNoThrow()
    {
        User user = CarPoolingApiCoreTests.ValidUser;
        IRepository<int, User> userRepository = SetDataInRepo([user]);

        Assert.DoesNotThrowAsync(async () => { await userRepository.DeleteById(user.Id); });
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public void DeleteThrowWhenNotExist(int id)
    {
        User user = CarPoolingApiCoreTests.ValidUser;
        user.Id = id;
        IRepository<int, User> userRepository = SetDataInRepo([user]);

        Assert.ThrowsAsync<RepoDataNotFoundException>(async () => { await userRepository.DeleteById(id + 1); }); //Add one to fail delete
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(5)]
    [TestCase(98)]
    public async Task DeleteHasBeenDeleted(int id)
    {
        User user = CarPoolingApiCoreTests.ValidUser;
        user.Id = id;
        IRepository<int, User> userRepository = SetDataInRepo([user]);

        await _repo.DeleteById(id);
        _repo.SaveChanges();

        Assert.ThrowsAsync<RepoDataNotFoundException>(async () => { await _repo.GetById(id); });
    }
}
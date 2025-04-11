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
        IRepository<int, UserTestModel> userRepository = SetDataInRepo([new UserTestModel { FirstName = "Test" }]);
        
        Assert.DoesNotThrowAsync(async () => { await userRepository.DeleteById(1); });
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public void DeleteThrowWhenNotExist(int id)
    {
        IRepository<int, UserTestModel> userRepository = SetDataInRepo([new UserTestModel { Id = id, FirstName = "Test" }]);

        Assert.ThrowsAsync<RepoDataNotFoundException>(async () => { await userRepository.DeleteById(id + 1); }); //Add one to fail delete
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(5)]
    [TestCase(98)]
    public async Task DeleteHasBeenDeleted(int id)
    {
        SetDataInRepo([new UserTestModel(){ Id = id, FirstName = "Test" }]);
        
        await _repo.DeleteById(id);

        Assert.ThrowsAsync<RepoDataNotFoundException>(async () =>
        {
            await _repo.GetById(id);
        });
    }
}
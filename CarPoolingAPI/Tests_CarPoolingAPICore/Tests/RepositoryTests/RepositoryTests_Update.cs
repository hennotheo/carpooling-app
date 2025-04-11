using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_UPDATE)]
public class RepositoryTests_Update : RepositoryTests
{
    [Test]
    public void UpdateNoThrow()
    {
        UserTestModel user = new UserTestModel() { Id = 1, FirstName = "Test" };
        IRepository<int, UserTestModel> userRepository = SetDataInRepo([user]);
        user.FirstName = "Updated";
        
        Assert.DoesNotThrowAsync(async () => { await userRepository.Update(user); });
    }
    
    [Test]
    public void UpdateThrowWhenDontExist()
    {
        UserTestModel user = new UserTestModel() { Id = 1, FirstName = "Test" };
        Assert.ThrowsAsync<RepoDataNotFoundException>(async () => { await _repo.Update(user); });
    }
    
    [Test]
    public async Task UpdateSucceed()
    {
        UserTestModel user = new UserTestModel() { Id = 1, FirstName = "Test" };
        IRepository<int, UserTestModel> userRepository = SetDataInRepo([user]);
        
        user.FirstName = "Updated";
        await userRepository.Update(user);
        
        UserTestModel updated = await userRepository.GetById(1);
        Assert.That(updated.FirstName, Is.EqualTo("Updated"));
    }
}
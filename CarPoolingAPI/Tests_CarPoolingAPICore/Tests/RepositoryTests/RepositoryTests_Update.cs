using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_UPDATE)]
public class RepositoryTests_Update
{
    [Test]
    public void UpdateNoThrow()
    {
        UserTestData user = new UserTestData() { Id = 1, Name = "Test" };
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>([user]);
        user.Name = "Updated";
        
        Assert.DoesNotThrowAsync(async () => { await userRepository.Update(user); });
    }
    
    [Test]
    public void UpdateThrowWhenDontExist()
    {
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>();
        
        UserTestData user = new UserTestData() { Id = 1, Name = "Test" };
        Assert.ThrowsAsync<RepoDataNotFoundException>(async () => { await userRepository.Update(user); });
    }
    
    [Test]
    public async Task UpdateSucceed()
    {
        UserTestData user = new UserTestData() { Id = 1, Name = "Test" };
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>([user]);
        
        user.Name = "Updated";
        await userRepository.Update(user);
        
        UserTestData updated = await userRepository.GetById(1);
        Assert.That(updated.Name, Is.EqualTo("Updated"));
    }
}
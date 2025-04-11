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
        User user = CarPoolingApiCoreTests.ValidUser;
        user.Id = 0;
        IRepository<int, User> userRepository = SetDataInRepo([user]);
        user.FirstName = "Updated";

        Assert.DoesNotThrowAsync(async () => { await userRepository.Update(user); });
    }

    [Test]
    public async Task UpdateThrowWhenDontExist()
    {
        User user = CarPoolingApiCoreTests.ValidUser;
        user.Id = 9999;

        // user = await _repo.Update(user);
        //
        // Assert.That(user.Id, Is.EqualTo(999));
        Assert.ThrowsAsync<RepoDataNotFoundException>(async () =>
        {
            await _repo.Update(user);
            _repo.SaveChanges();
        });
    }

    [Test]
    public async Task UpdateSucceed()
    {
        User user = CarPoolingApiCoreTests.ValidUser;
        IRepository<int, User> userRepository = SetDataInRepo([user]);

        user.FirstName = "Updated";
        await userRepository.Update(user);

        User updated = await userRepository.GetById(user.Id);
        Assert.That(updated.FirstName, Is.EqualTo("Updated"));
    }
}
using CarPoolingAPICore.Models;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_POST)]
public class RepositoryTests_Add : RepositoryTests
{
    [Test]
    public void AddNoThrow()
    {
        Assert.DoesNotThrowAsync(async () => { await _repo.Add(CarPoolingApiCoreTests.ValidUser); });
    }

    [Test]
    [TestCase("Test")]
    [TestCase("Test2")]
    public async Task AddAndGetIt(string name)
    {
        User user = CarPoolingApiCoreTests.ValidUser;
        user.FirstName = name;
        await _repo.Add(user);
        _repo.SaveChanges();
        User? found = await _repo.GetFirstByPredicate(user => user.FirstName == name);
        
        Assert.That(found.FirstName, Is.EqualTo(name));
    }
}
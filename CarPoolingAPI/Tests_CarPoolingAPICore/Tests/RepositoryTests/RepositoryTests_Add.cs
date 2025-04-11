using CarPoolingAPICore.Models;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_POST)]
public class RepositoryTests_Add : RepositoryTests
{
    [Test]
    public void AddNoThrow()
    {
        Assert.DoesNotThrowAsync(async () => { await _repo.Add(new UserTestModel()); });
    }

    [Test]
    [TestCase(1, "Test")]
    [TestCase(3, "Test2")]
    public void AddAndGetIt(int id, string name)
    {
        UserTestModel user = new UserTestModel()
        {
            Id = id, FirstName = name
        };
        _repo.Add(user);

        Assert.That(_repo.GetById(id).GetAwaiter().GetResult().FirstName, Is.EqualTo(name));
    }
}
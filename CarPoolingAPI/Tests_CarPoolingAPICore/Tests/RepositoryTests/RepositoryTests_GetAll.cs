using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_GET)]
public class RepositoryTests_GetAll : RepositoryTests
{
    [Test]
    public void GetAllNoThrow()
    {
        Assert.DoesNotThrowAsync(async () =>
        {
            var users = await _repo.GetAll();
        });
    }

    [Test]
    [TestCase(2)]
    [TestCase(6)]
    [TestCase(999)]
    public async Task GetAll_MaxCount(int max)
    {
        List<UserTestModel> users = new List<UserTestModel>();
        for (int i = 0; i < 50; i++)
        {
            users.Add(new UserTestModel()
            {
                FirstName = "User" + i
            });
        }

        IRepository<int, UserTestModel> userRepository = SetDataInRepo(users.ToArray());
        IEnumerable<UserTestModel> result = await userRepository.GetAll(max);
        Assert.That(result.Count, Is.LessThanOrEqualTo(max));
    }
}
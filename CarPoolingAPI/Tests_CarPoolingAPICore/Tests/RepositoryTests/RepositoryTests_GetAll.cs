using CarPoolingAPICore.Interface;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_GET)]
public class RepositoryTests_GetAll
{
    [Test(TestOf = typeof(UserTestData))]
    public void GetAllNoThrow()
    {
        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>();
        Assert.DoesNotThrowAsync(async () =>
        {
            var users = await userRepository.GetAll();
        });
    }

    [Test(TestOf = typeof(UserTestData))]
    [TestCase(2)]
    [TestCase(6)]
    [TestCase(999)]
    public async Task GetAll_MaxCount(int max)
    {
        List<UserTestData> users = new List<UserTestData>();
        for (int i = 0; i < 50; i++)
        {
            users.Add(new UserTestData()
            {
                Id = i,
                Name = "User" + i
            });
        }

        IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>(users.ToArray());
        ICollection<UserTestData> result = userRepository.GetAll(max).Result.ToList();
        Assert.That(result.Count, Is.LessThanOrEqualTo(max));
    }
}
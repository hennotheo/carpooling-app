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
}
using CarPoolingAPICore.Interface;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_INITIALIZATION)]
public class RepositoryTests_Init
{
    [Test]
    public void CreateRepository()
    {
        Assert.DoesNotThrow(() =>
        {
            IRepository<int, UserTestData> userRepository = new TestRepository<UserTestData>();
        });
    }
}
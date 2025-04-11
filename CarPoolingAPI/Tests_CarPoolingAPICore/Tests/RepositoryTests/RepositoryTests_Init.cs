using CarPoolingAPICore.Data;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using CarPoolingAPICore.Repository;
using Microsoft.EntityFrameworkCore;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

[TestFixture(Category = CarPoolingApiCoreTests.CATEGORY_INITIALIZATION)]
public class RepositoryTests_Init : RepositoryTests
{
    [Test]
    public void CreateRepository()
    {
        Assert.DoesNotThrow(() =>
        {
            IRepository<int, UserTestModel> userRepository = new Repository<int, UserTestModel>(_context);
        });
    }
}
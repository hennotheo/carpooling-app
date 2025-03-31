using CarPoolingAPICore.Models;
using CarPoolingAPICore.Repository;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Get")]
public class UserServiceTests_Get : UserServiceTests
{
    [Test]
    public void GetAllUsers_NoThrow()
    {
        _mockUserRepo.Setup(repo => repo.GetAll(10)).ReturnsAsync(_data);

        Assert.DoesNotThrow(() => _service.SearchUsers(10));
    }

    [Test]
    public void GetUsers_ReturnNonNullListOfUsers()
    {
        _mockUserRepo.Setup(repo => repo.GetAll(10)).ReturnsAsync(_data);

        var result = _service.SearchUsers(10);
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public void GetUsersById_ReturnValid(int id)
    {
        _mockUserRepo.Setup(repo => repo.GetById(0)).ReturnsAsync(new User() { Id = id, Name = "John" });

        User? user = _service.GetUserById(id);
        Assert.That(user, Is.Not.Null);
    }
}
using CarPoolingAPI.DTO;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Get")]
public class UserServiceTests_Get : UserServiceTests
{
    [Test]
    public async Task GetAllUsers_NoThrow()
    {
        _mockUserRepo.Setup(repo => repo.GetAll(10)).ReturnsAsync(_data);

        Assert.DoesNotThrowAsync(() => _service.SearchUsers(10));
    }

    [Test]
    public async Task GetUsers_ReturnNonNullListOfUsers()
    {
        _mockUserRepo.Setup(repo => repo.GetAll(10)).ReturnsAsync(_data);

        var result = await _service.SearchUsers(10);
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public async Task GetUsersById_ReturnValid(int id)
    {
        _mockUserRepo.Setup(repo => repo.GetById(id)).ReturnsAsync(TestData.ValidUser);

        UserProfileDto user = await _service.GetUserById(id);
        Assert.That(user, Is.Not.Default);
    }
}
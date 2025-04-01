using System.Net;
using CarPoolingAPI.Exceptions;
using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Models;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Post")]
public class UserServiceTests_Post : UserServiceTests
{
    private readonly User _validUser = new() { Name = "John" };
    
    [Test]
    public void AddUser_NoThrow()
    {
        SetupUserMockingDoesntExist();

        Assert.DoesNotThrowAsync(() => _service.AddUser(_validUser));
    }

    [Test]
    public async Task AddUser_AddSucceed()
    {
        SetupUserMockingDoesntExist();
        _mockUserRepo.Setup(repo => repo.Add(It.IsAny<User>())).Verifiable();
        _mockUserRepo.CallBase = false;

        await _service.AddUser(_validUser);

        _mockUserRepo.Verify(repo => repo.Add(It.IsAny<User>()), Times.Once);
        Assert.Pass();
    }

    [Test]
    public void AddUser_ThrowWhenAlreadyExists()
    {
        _mockUserRepo.Setup(repo => repo.GetFirstByPredicate(It.IsAny<Func<User, bool>>())).ReturnsAsync(_validUser);//Find it in data

        Assert.ThrowsAsync<AlreadyExistsServiceException>(async () => await _service.AddUser(_validUser));
    }

    [Test]
    public void AddUser_ThrowWhenUserEmpty()
    {
        SetupUserMockingDoesntExist();

        Assert.ThrowsAsync<BadRequestServiceException>(() => _service.AddUser(new User()));
    }

    private void SetupUserMockingDoesntExist()
    {
        _mockUserRepo.Setup(repo => repo.GetFirstByPredicate(It.IsAny<Func<User, bool>>())).Throws(new RepoDataNotFoundException());
    }
}
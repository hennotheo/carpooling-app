using System.Net;
using CarPoolingAPI.Exceptions;
using CarPoolingAPICore.Models;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Post")]
public class UserServiceTests_Post : UserServiceTests
{
    [Test]
    public void AddUser_NoThrow()
    {
        Assert.DoesNotThrowAsync(() => _service.AddUser(new User()));
    }

    [Test]
    public async Task AddUser_AddSucceed()
    {
        _mockUserRepo.Setup(repo => repo.Add(It.IsAny<User>())).Verifiable();

        await _service.AddUser(new User());

        _mockUserRepo.Verify(repo => repo.Add(It.IsAny<User>()), Times.Once);
        Assert.Pass();
    }

    [Test]
    public async Task AddUser_ThrowWhenAlreadyExists()
    {
        User user = new User() { Name = "John" };

        await _service.AddUser(user);
        Assert.ThrowsAsync<AlreadyExistsServiceException>(() => _service.AddUser(user));
    }
    
    [Test]
    public void AddUser_ThrowWhenUserEmpty()
    {
        User user = new User() { };
        
        Assert.ThrowsAsync<BadRequestServiceException>(() => _service.AddUser(user));
    }
}
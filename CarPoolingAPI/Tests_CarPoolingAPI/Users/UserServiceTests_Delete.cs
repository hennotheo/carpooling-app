using CarPoolingAPI.Exceptions;
using CarPoolingAPI.Services;
using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using CarPoolingAPICore.Repository;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Delete")]
public class UserServiceTests_Delete : UserServiceTests
{
    [Test]
    public void DeleteUser_NoThrow()
    {
        Assert.DoesNotThrow(() => _service.DeleteUser(0));
    }

    [Test]
    public void DeleteUser_DeleteSucceed()
    {
        _mockUserRepo.Setup(repo => repo.DeleteById(0)).Verifiable();

        _service.DeleteUser(0);
        _mockUserRepo.Verify(repo => repo.DeleteById(0), Times.Once);
        
        Assert.Pass();
    }

    [Test]
    public void DeleteUser_ThrowWhenNotExists()
    {
        _mockUserRepo.Setup(repo => repo.DeleteById(0)).ThrowsAsync(new RepoDataNotFoundException());

        Assert.ThrowsAsync<NotFoundServiceException>(() => _service.DeleteUser(0));
    }
}
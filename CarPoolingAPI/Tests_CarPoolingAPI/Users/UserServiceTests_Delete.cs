using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Models;
using CarPoolingAPICore.Repository;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Delete")]
public class UserServiceTests_Delete : UserServiceTests
{
    [Test]
    public void DeleteUser_NoThrow()
    {
        _mockUserRepo.Setup(repo => repo.DeleteById(0)).Callback(() => Task.Delay(1));
        _service.DeleteUser(0);

        Assert.DoesNotThrow(() => _service.DeleteUser(0));
    }

    [Test]
    public void DeleteUser_DeleteSucceed()
    {
        bool deleted = false;

        _mockUserRepo.Setup(repo => repo.DeleteById(0)).Callback(() => deleted = true);
        _service.DeleteUser(0);

        Assert.That(deleted, Is.True);
    }

    [Test]
    public void DeleteUser_ThrowWhenNotExists()
    {
        _mockUserRepo.Setup(repo => repo.DeleteById(0)).Throws<RepoDataNotFoundException>();
        
        Assert.Throws<RepoDataNotFoundException>(() => _service.DeleteUser(0));
    }
}
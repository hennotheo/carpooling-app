using System.Text.Json.Serialization;
using CarPoolingAPI.Exceptions;
using CarPoolingAPICore.Exceptions;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Delete")]
public class UserApiTests_Delete : UserApiTests
{
    [Test]
    public async Task DeleteUser_Exist()
    {
        _mockUserService.Setup(service => service.DeleteUser(0)).Callback(() => Task.Delay(1));
        HttpResponseMessage response = await _client.DeleteAsync(CarPoolingAPITests.USER_ROOT + "/" + 0);

        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task DeleteUser_NotFoundWhenUserDoesntExist()
    {
        _mockUserService.Setup(service => service.DeleteUser(0)).ThrowsAsync(new NotFoundServiceException(""));
        HttpResponseMessage response = await _client.DeleteAsync(CarPoolingAPITests.USER_ROOT + "/" + 0);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
    }

    [Test]
    public async Task DeleteUser_Succeed()
    {
        HttpResponseMessage response = await _client.DeleteAsync(CarPoolingAPITests.USER_ROOT + "/" + 0);

        Assert.That(response.IsSuccessStatusCode);
    }
}
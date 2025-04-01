using System.Text;
using System.Text.Json;
using CarPoolingAPI.Exceptions;
using CarPoolingAPICore.Models;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Post")]
public class UserApiTests_Post : UserApiTests
{
    [Test]
    public async Task AddUser_Exist()
    {
        User user = new User() { Id = 0, Name = "John" };
        _mockUserService.Setup(service => service.AddUser(new User())).Callback(() => Task.Delay(1));

        HttpResponseMessage response = await AddUserPost(user);

        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task AddUser_ConflictIfUserAlreadyExists()
    {
        User user = new User() { Id = 0, Name = "John" };
        _mockUserService.Setup(service => service.AddUser(It.IsAny<User>())).ThrowsAsync(new AlreadyExistsServiceException(""));

        HttpResponseMessage response = await AddUserPost(user);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Conflict));
    }

    [Test]
    public async Task AddUser_BadRequestWhenUserEmpty()
    {
        HttpResponseMessage response = await AddUserPost(new User() { });

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));
    }

    private async Task<HttpResponseMessage> AddUserPost(User user)
    {
        return await _client.PostAsync(
            CarPoolingAPITests.USER_ROOT,
            new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json"));
    }
}
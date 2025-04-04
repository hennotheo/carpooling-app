using System.Text;
using System.Text.Json;
using CarPoolingAPI.DTO;
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
        _mockUserService.Setup(service => service.AddUser(It.IsAny<UserSignUpRequestDto>())).ReturnsAsync(TestData.ValidUserProfileResultDto);

        HttpResponseMessage response = await AddUserPost(TestData.ValidUser);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
    }

    [Test]
    public async Task AddUser_ConflictIfUserAlreadyExists()
    {
        _mockUserService.Setup(service => service.AddUser(It.IsAny<UserSignUpRequestDto>())).ThrowsAsync(new AlreadyExistsServiceException(""));

        HttpResponseMessage response = await AddUserPost(TestData.ValidUser);

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
            TestData.USER_REQUEST_ROOT,
            new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json"));
    }
}
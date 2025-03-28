using Microsoft.AspNetCore.Mvc.Testing;
using CarPoolingAPI.Services;
using CarPoolingAPICore.Models;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Get")]
public class UserApiTests_Get
{
    private HttpClient _client;
    private Mock<IUserService> _mockUserService;

    private List<User> _data = new List<User>
    {
        new User { Id = 1, Name = "John" },
        new User { Id = 2, Name = "Jane" }
    };

    [SetUp]
    public void Setup()
    {
        var factory = new WebApplicationFactory<Program>();
        _client = factory.CreateClient();
        _mockUserService = new Mock<IUserService>();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
    }

    [Test]
    public async Task GetUsersById_Exist()
    {
        _mockUserService.Setup(service => service.GetUserById(0)).Returns(new User() { Id = 0, Name = "John" });

        HttpResponseMessage response = await _client.GetAsync($"/User/0");

        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task GetUsers_ReturnListOfUsers()
    {
        _mockUserService.Setup(service => service.SearchUsers(10)).Returns(_data);

        HttpResponseMessage response = await _client.GetAsync(CarPoolingAPITests.USER_ROOT);

        var responseString = await response.Content.ReadAsStringAsync();
        var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(responseString);
        Assert.That(users, Is.Not.Null);
    }

    [Test]
    public async Task GetUser_ReturnNotNotFound()
    {
        _mockUserService.Setup(service => service.SearchUsers(10)).Returns(_data);

        HttpResponseMessage response = await _client.GetAsync(CarPoolingAPITests.USER_ROOT);

        Assert.That(response.IsSuccessStatusCode, Is.True);
    }
}
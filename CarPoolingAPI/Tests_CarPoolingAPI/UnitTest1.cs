using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using CarPoolingAPI;
using CarPoolingAPI.Services;
using CarPoolingAPICore.Models;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Get")]
public class ApiTests
{
    private HttpClient _client;
    private Mock<IUserService> _mockUserService;

    private List<UserController> _data = new List<UserController>
    {
        new UserController { Id = 1, Name = "John" },
        new UserController { Id = 2, Name = "Jane" }
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
    public async Task GetUsers_ReturnSuccess()
    {
        _mockUserService.Setup(service => service.GetAllUsers()).Returns(_data);

        HttpResponseMessage response = await _client.GetAsync("/User");

        Assert.That(response.IsSuccessStatusCode, Is.True);
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.That(responseString, Is.Not.Null);
    }

    [Test]
    public async Task GetUsers_ReturnListOfUsers()
    {
        _mockUserService.Setup(service => service.GetAllUsers()).Returns(_data);
        
        HttpResponseMessage response = await _client.GetAsync("/User");

        var responseString = await response.Content.ReadAsStringAsync();
        var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserController>>(responseString);
        Assert.That(users, Is.Not.Null);
    }
}
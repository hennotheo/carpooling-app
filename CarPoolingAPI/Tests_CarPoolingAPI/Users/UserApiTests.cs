using CarPoolingAPI.Services;
using CarPoolingAPICore.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Tests_CarPoolingAPI;

public abstract class UserApiTests
{
    protected HttpClient _client;
    protected Mock<IUserService> _mockUserService;

    protected List<User> _data = new List<User>
    {
        new User { Id = 1, FirstName = "John" },
        new User { Id = 2, FirstName = "Jane" }
    };

    [SetUp]
    public virtual void Setup()
    {
        _mockUserService = new Mock<IUserService>();
        var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => { builder.ConfigureServices(services => { services.AddSingleton(_mockUserService.Object); }); });
        _client = factory.CreateClient();
    }

    [TearDown]
    public virtual void TearDown()
    {
        _client.Dispose();
    }
}
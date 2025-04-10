using System.Text;
using CarPoolingAPI.DTO;
using CarPoolingAPI.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Authentication")]
public class AuthenticationApiTests_Login
{
    private HttpClient _client;
    private Mock<IAuthenticationService> _mockAuthenticationService;

    [SetUp]
    public virtual void Setup()
    {
        _mockAuthenticationService = new Mock<IAuthenticationService>();

        var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => { builder.ConfigureServices(services => { services.AddSingleton(_mockAuthenticationService.Object); }); });
        _client = factory.CreateClient();
    }

    [TearDown]
    public virtual void TearDown()
    {
        _client.Dispose();
    }

    [Test]
    public async Task LoginUser_Exist()
    {
        _mockAuthenticationService.Setup((auth) => auth.Login(It.IsAny<UserLoginRequestDto>())).Returns(Task.FromResult(TestData.ValidAuthResponse));

        var content = new StringContent(JsonConvert.SerializeObject(TestData.ValidRegisterRequest), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"{TestData.AUTH_REQUEST_ROOT}/login", content);

        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task LoginUser_ValidReturnToken()
    {
        _mockAuthenticationService.Setup((auth) => auth.Login(It.IsAny<UserLoginRequestDto>())).Returns(Task.FromResult(TestData.ValidAuthResponse));

        var content = new StringContent(JsonConvert.SerializeObject(TestData.ValidRegisterRequest), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"{TestData.AUTH_REQUEST_ROOT}/login", content);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();

        Assert.That(responseString, Is.Not.Null);
        Assert.That(responseString.Contains("token"), Is.True);
    }

    [Test]
    public async Task LoginUser_ValidReturnUserId()
    {
        _mockAuthenticationService.Setup((auth) => auth.Login(It.IsAny<UserLoginRequestDto>())).Returns(Task.FromResult(TestData.ValidAuthResponse));

        var content = new StringContent(JsonConvert.SerializeObject(TestData.ValidRegisterRequest), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"{TestData.AUTH_REQUEST_ROOT}/login", content);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();

        Assert.That(responseString, Is.Not.Null);
        Assert.That(responseString.Contains("userId"), Is.True);
    }
}
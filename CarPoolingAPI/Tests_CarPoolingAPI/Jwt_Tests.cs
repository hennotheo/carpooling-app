using System.Text;
using CarPoolingAPI.DTO;
using CarPoolingAPI.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Authentication")]
public class AuthenticationApiTests
{
    private HttpClient _client;

    [SetUp]
    public virtual void Setup()
    {
        var factory = new WebApplicationFactory<Program>();
        _client = factory.CreateClient();
    }

    [TearDown]
    public virtual void TearDown()
    {
        _client.Dispose();
    }

    [Test]
    public async Task RegisterUser_Exist()
    {
        var content = new StringContent(JsonConvert.SerializeObject(TestData.ValidRegisterRequest), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/Auth/register", content);

        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task RegisterUser_ReturnToken()
    {
        var content = new StringContent(JsonConvert.SerializeObject(TestData.ValidRegisterRequest), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/Auth/register", content);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        
        Assert.That(responseString, Is.Not.Null);
        Assert.That(responseString.Contains("token"), Is.True);
    }
}
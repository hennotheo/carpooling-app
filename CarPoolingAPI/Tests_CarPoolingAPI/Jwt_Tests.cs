using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Authentication")]
public class Jwt_Tests
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
    public async Task GenerateJwtToken_ShouldReturnToken()
    {
        var loginModel = new { Email = "testuser", Password = "password" };
        var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync("/api/Auth/login", content);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        
        Assert.That(responseString, Is.Not.Null);
        Assert.That(responseString.Contains("token"), Is.True);
    }
}
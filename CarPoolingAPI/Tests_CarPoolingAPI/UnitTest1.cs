using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using CarPoolingAPI;
using CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPI;


[TestFixture(Category = "Get")]
public class UserTests
{
    private HttpClient _client;
    
    [SetUp]
    public void Setup()
    {
        var factory = new WebApplicationFactory<Program>();
        _client = factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
    }

    [Test]
    public async Task GetUsers_ReturnSuccess()
    {
        HttpResponseMessage response = await _client.GetAsync("/users");
        
        Assert.That(response.IsSuccessStatusCode, Is.True);
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.That(responseString, Is.Not.Null);
    }
    
    [Test]
    public async Task GetUsers_ReturnListOfUsers()
    {
        HttpResponseMessage response = await _client.GetAsync("/users");
        
        var responseString = await response.Content.ReadAsStringAsync();
        var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(responseString);
        Assert.That(users, Is.Not.Null);
    }
}
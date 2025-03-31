using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Get")]
public class UserApiTests_Get : UserApiTests
{
    [Test]
    public async Task GetUserById_Exist()
    {
        _mockUserService.Setup(service => service.GetUserById(0)).Returns(new User() { Id = 0, Name = "John" });
        HttpResponseMessage response = await GetUserByIdRequest(0);

        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task GetUserById_ReturnValidResult()
    {
        _mockUserService.Setup(service => service.GetUserById(0)).Returns(new User() { Id = 0, Name = "John" });
        HttpResponseMessage response = await GetUserByIdRequest(0);

        var responseString = await response.Content.ReadAsStringAsync();
        var user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(responseString);

        Assert.That(user.Name, Is.EqualTo("John"));
    }
    
    [Test]
    public async Task SearchUsers_Exist()
    {
        _mockUserService.Setup(service => service.SearchUsers(25)).Returns(_data);

        HttpResponseMessage response = await _client.GetAsync(CarPoolingAPITests.USER_ROOT + CarPoolingAPITests.SEARCH_TEMPLATE);

        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task SearchUsers_ReturnListOfUsers()
    {
        _mockUserService.Setup(service => service.SearchUsers(25)).Returns(_data);

        HttpResponseMessage response = await _client.GetAsync(CarPoolingAPITests.USER_ROOT + CarPoolingAPITests.SEARCH_TEMPLATE);

        var responseString = await response.Content.ReadAsStringAsync();
        var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(responseString);
        Assert.That(users, Is.Not.Null);
    }


    private async Task<HttpResponseMessage> GetUserByIdRequest(int id)
    {
        return await _client.GetAsync(CarPoolingAPITests.USER_ROOT + "/" + id);
    }
}
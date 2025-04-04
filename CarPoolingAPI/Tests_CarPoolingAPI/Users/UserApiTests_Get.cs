using CarPoolingAPI.DTO;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Get")]
public class UserApiTests_Get : UserApiTests
{
    [Test]
    public async Task GetUserById_Exist()
    {
        _mockUserService.Setup(service => service.GetUserById(0)).Returns(Task.FromResult(TestData.ValidUserProfileDto));
        HttpResponseMessage response = await GetUserByIdRequest(0);

        Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task GetUserById_ReturnValidResult()
    {
        UserProfileDto validUser = TestData.ValidUserProfileDto;
        _mockUserService.Setup(service => service.GetUserById(0)).Returns(Task.FromResult(validUser));
        HttpResponseMessage response = await GetUserByIdRequest(0);

        var responseString = await response.Content.ReadAsStringAsync();
        var user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserProfileDto>(responseString);

        Assert.That(user, Is.EqualTo(validUser));
    }

    [Test]
    public async Task SearchUsers_Exist()
    {
        _mockUserService.Setup(service => service.SearchUsers(25)).Returns(() => Task.FromResult((ICollection<UserProfileDto>)_data.Select(UserProfileDto.MapFromUser).ToList()));
        
          HttpResponseMessage response = await _client.GetAsync(TestData.USER_ROOT + TestData.SEARCH_TEMPLATE);
        
          Assert.That(response.IsSuccessStatusCode, Is.True);
    }

    [Test]
    public async Task SearchUsers_ReturnListOfUsers()
    {
        _mockUserService.Setup(service => service.SearchUsers(25)).Returns(() => Task.FromResult((ICollection<UserProfileDto>)_data.Select(UserProfileDto.MapFromUser).ToList()));

        HttpResponseMessage response = await _client.GetAsync(TestData.USER_ROOT + TestData.SEARCH_TEMPLATE);

        var responseString = await response.Content.ReadAsStringAsync();
        var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(responseString);
        Assert.That(users, Is.Not.Null);
    }


    private async Task<HttpResponseMessage> GetUserByIdRequest(int id)
    {
        return await _client.GetAsync(TestData.USER_ROOT + "/" + id);
    }
}
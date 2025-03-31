namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Delete")]
public class UserApiTests_Delete : UserApiTests
{
    [Test]
    public async Task DeleteUser_Exist()
    {
        _mockUserService.Setup(service => service.DeleteUser(0)).Callback(() => Task.Delay(1));
        HttpResponseMessage response = await _client.DeleteAsync(CarPoolingAPITests.USER_ROOT);

        Assert.That(response.IsSuccessStatusCode, Is.True);
    }
}
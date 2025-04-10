using CarPoolingAPI.DTO;
using CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPI;

public static class TestData
{
    public const string API_ROOT = "/api";
    public const string USER_ROOT = "/User";
    public const string AUTH_ROOT = "/Auth";
    public const string SEARCH_TEMPLATE = "/SEARCH";

    public const string USER_REQUEST_ROOT = TestData.API_ROOT + TestData.USER_ROOT;
    public const string AUTH_REQUEST_ROOT = TestData.API_ROOT + TestData.AUTH_ROOT;
    public const string VALID_TOKEN = "zpojdzjdozjdojakpdp^q";

    public static readonly User ValidUser = new() { Id = 0, FirstName = "John", LastName = "zz", Email = "iojojoj", HashedPassword = "123"};
    public static readonly UserProfileResultDto ValidUserProfileResultDto = new() { Id = 0, FirstName = "John", LastName = "K", Email = "john@jonmail.com" };
    public static readonly UserRegisterRequestDto ValidRegisterRequest = new() { FirstName = "John", LastName = "Doe", Email = "john.doe@test.com", Password = "PASSword123?" };
    public static readonly UserAuthResponseDto ValidAuthResponse = new() { Token = VALID_TOKEN, UserId = 0 };
    public static readonly UserLoginRequestDto ValidLoginRequestDto = new() { Email = "john.doe@gmail.com", Password = "PASSword123?" };
}
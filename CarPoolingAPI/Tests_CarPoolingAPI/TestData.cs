using CarPoolingAPI.DTO;
using CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPI;

public static class TestData
{
    public const string USER_ROOT = "/User";
    public const string SEARCH_TEMPLATE = "/SEARCH";
    
    public static readonly User ValidUser = new() { Id = 0, FirstName = "John", LastName = "zz", Email = "iojojoj"};
    public static readonly UserProfileDto ValidUserProfileDto = new() { Id = 0, FirstName = "John", LastName = "K", Email = "john@jonmail.com"};
}
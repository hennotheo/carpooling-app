using CarPoolingAPICore.Models;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

public class CarPoolingApiCoreTests
{
    public const string CATEGORY_INITIALIZATION = "Initialization";
    public const string CATEGORY_GET = "Get";
    public const string CATEGORY_POST = "Post";
    public const string CATEGORY_UPDATE = "Update";
    public const string CATEGORY_DELETE = "Delete";

    public static readonly UserTestModel ValidUser = new UserTestModel()
    {
        Id = 0,
        FirstName = "Test",
        LastName = "Test",
        Email = "test@test.com",
        HashedPassword = "zojozdjodozokd^pd^p"
    };
}
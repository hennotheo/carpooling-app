using CarPoolingAPICore.Repository;

namespace Tests_CarPoolingAPICore;

internal class TestRepository<T> : Repository<int, T>
{
    private readonly List<T> _userTestData;

    protected override IList<T> Entities => _userTestData;

    public TestRepository(T[]? data = null) : base(null)
    {
        _userTestData = data != null ? [..data] : [];
    }
}
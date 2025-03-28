using CarPoolingAPICore.Repository;

namespace Tests_CarPoolingAPICore;

internal class TestRepository<T> : BaseRepository<int, T>
{
    private readonly List<T> _userTestData;

    protected override IEnumerable<T> Entities => _userTestData;

    public TestRepository(T[]? data = null)
    {
        _userTestData = data != null ? [..data] : [];
    }
}
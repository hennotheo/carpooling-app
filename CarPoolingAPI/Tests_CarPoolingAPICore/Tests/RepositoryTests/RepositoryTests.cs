using CarPoolingAPICore.Data;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using CarPoolingAPICore.Repository;
using Microsoft.EntityFrameworkCore;
using Tests_CarPoolingAPICore.Data;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

public class RepositoryTests
{
    protected TestDbContext _context;
    protected IRepository<int, UserTestModel> _repo;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        _context = new TestDbContext(options);
        _context.Database.EnsureCreated();
        
        _repo = new Repository<int, UserTestModel>(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context?.Database.EnsureDeleted();
        
        _context?.Dispose();
        _repo?.Dispose();
    }

    public IRepository<int, UserTestModel> SetDataInRepo(IEnumerable<UserTestModel> entities)
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        _context.Set<UserTestModel>().AddRange(entities);
        _context.SaveChanges();
        
        return _repo;
    }
}
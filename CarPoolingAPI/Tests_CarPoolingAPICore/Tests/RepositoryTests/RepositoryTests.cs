using CarPoolingAPICore.Data;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using CarPoolingAPICore.Repository;
using Microsoft.EntityFrameworkCore;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore;

public class RepositoryTests
{
    protected ApplicationDbContext _context;
    protected IRepository<int, User> _repo;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        _context = new ApplicationDbContext(options);
        _context.Database.EnsureCreated();
        
        _repo = new Repository<int, User>(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context?.Database.EnsureDeleted();
        
        _context?.Dispose();
        _repo?.Dispose();
    }

    public IRepository<int, User> SetDataInRepo(IEnumerable<User> entities)
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        _context.Set<User>().AddRange(entities);
        _context.SaveChanges();
        
        return _repo;
    }
}
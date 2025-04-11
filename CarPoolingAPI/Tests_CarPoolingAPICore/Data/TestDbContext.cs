using Microsoft.EntityFrameworkCore;
using Tests_CarPoolingAPICore.Models;

namespace Tests_CarPoolingAPICore.Data;

public class TestDbContext : DbContext
{
    public DbSet<UserTestModel> Users { get; set; }

    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
        
    }
}
using CarPoolingAPICore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarPoolingAPICore.Data;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\car;Integrated Security=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
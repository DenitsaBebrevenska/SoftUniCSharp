using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase.Data;
public class SalesContext : DbContext
{
    public SalesContext()
    {

    }

    public SalesContext(DbContextOptions options)
        : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User));
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

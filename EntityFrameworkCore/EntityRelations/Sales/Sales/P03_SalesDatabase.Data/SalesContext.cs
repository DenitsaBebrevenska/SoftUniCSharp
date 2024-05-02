using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Models;

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

    public DbSet<Sale> Sales { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User));
        }

        base.OnConfiguring(optionsBuilder);
    }
}

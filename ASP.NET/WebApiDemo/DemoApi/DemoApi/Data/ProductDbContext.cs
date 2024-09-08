using Microsoft.EntityFrameworkCore;

namespace DemoApi.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) :
        base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; }
}

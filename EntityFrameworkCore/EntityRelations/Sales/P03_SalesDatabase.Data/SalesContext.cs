using Bogus;
using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

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

    public void SeedData()
    {
        if (!Customers.Any())
        {
            var customerFake = new Faker<Customer>()
                .RuleFor(c => c.Name, f => f.Person.FirstName)
                .RuleFor(c => c.CreditCardNumber, f => f.Finance.Account())
                .RuleFor(c => c.Email, f => f.Person.Email);

            var customers = customerFake.Generate(10);
            Customers.AddRange(customers);

            SaveChanges();
        }

        if (!Products.Any())
        {
            var productFake = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.Product())
                .RuleFor(p => p.Price, f => f.Finance.Amount())
                .RuleFor(p => p.Quantity, f => f.Finance.Amount());

            var products = productFake.Generate(10);
            Products.AddRange(products);
            SaveChanges();

        }

        if (!Stores.Any())
        {
            var storeFake = new Faker<Store>()
                .RuleFor(s => s.Name, f => f.Person.FirstName);

            var stores = storeFake.Generate(10);
            Stores.AddRange(stores);
            SaveChanges();
        }

        if (!Sales.Any())
        {
            var saleFaker = new Faker<Sale>()
                .RuleFor(s => s.Date, f => f.Date.Past())
                .RuleFor(s => s.ProductId, f => f.Random.Number(1, 10))
                .RuleFor(s => s.StoreId, f => f.Random.Number(1, 10))
                .RuleFor(s => s.CustomerId, f => f.Random.Number(1, 10));

            var sales = saleFaker.Generate(5);
            Sales.AddRange(sales);
            SaveChanges();
        }
    }
}

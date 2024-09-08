using DemoApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Services;

public class ProductService : IProductService
{
    private readonly ProductDbContext _context;

    public ProductService(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await _context
            .Products
            .AsNoTracking()
            .ToListAsync();

    public async Task<Product?> GetByIdAsync(int id)
        => await _context
            .Products
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Product> AddAsync(string name, string description)
    {
        var product = new Product()
        {
            Name = name,
            Description = description
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task UpdateAsync(int id, Product product)
    {
        var productDb = await _context
            .Products
            .FindAsync(id);

        productDb!.Name = product.Name;
        productDb.Description = product.Description;

        await _context.SaveChangesAsync();
    }

    public async Task PartialUpdateAsync(int id, Product product)
    {
        var productDb = await _context
            .Products
            .FindAsync(id);

        productDb!.Name = string.IsNullOrEmpty(product.Name)
            ? productDb.Name : product.Name;
        productDb.Description = string.IsNullOrEmpty(product.Description)
            ? productDb.Description : product.Description;

        await _context.SaveChangesAsync();
    }

    public async Task<Product> DeleteAsync(int id)
    {
        var product = await _context
            .Products
            .FindAsync(id);

        _context.Products.Remove(product!);
        await _context.SaveChangesAsync();

        return product!;
    }
}

using DemoApi.Data;

namespace DemoApi.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task<Product> AddAsync(string name, string description);

    Task UpdateAsync(int id, Product product);

    Task PartialUpdateAsync(int id, Product product);

    Task<Product> DeleteAsync(int id);
}

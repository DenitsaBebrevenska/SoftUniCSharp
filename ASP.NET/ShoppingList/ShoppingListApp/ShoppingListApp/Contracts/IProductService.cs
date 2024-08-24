using ShoppingListApp.Models;

namespace ShoppingListApp.Contracts;

public interface IProductService
{
	Task<IEnumerable<ProductViewModel>> GetProductsAsync();

	Task<ProductViewModel> GetProductAsync(int id);

	Task AddProductAsync(ProductViewModel product);

	Task UpdateProductAsync(ProductViewModel product);

	Task DeleteProductAsync(int id);
}

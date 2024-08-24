using ShoppingListApp.Contracts;
using ShoppingListApp.Data;
using ShoppingListApp.Models;

namespace ShoppingListApp.Services;

public class ProductService : IProductService
{
	private readonly ShoppingListContext _context;

	public ProductService(ShoppingListContext context)
	{
		_context = context;
	}
	public Task<IEnumerable<ProductViewModel>> GetProductsAsync()
	{
		throw new NotImplementedException();
	}


	public Task<ProductViewModel> GetProductAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task AddProductAsync(ProductViewModel product)
	{
		throw new NotImplementedException();
	}

	public Task UpdateProductAsync(ProductViewModel product)
	{
		throw new NotImplementedException();
	}

	public Task DeleteProductAsync(int id)
	{
		throw new NotImplementedException();
	}
}

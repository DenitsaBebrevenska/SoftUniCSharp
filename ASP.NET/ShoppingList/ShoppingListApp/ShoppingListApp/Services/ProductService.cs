using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Contracts;
using ShoppingListApp.Data;
using ShoppingListApp.Data.Models;
using ShoppingListApp.Models;

namespace ShoppingListApp.Services;

public class ProductService : IProductService
{
	private readonly ShoppingListContext _context;

	public ProductService(ShoppingListContext context)
	{
		_context = context;
	}
	public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
	{
		return await _context.Products
			.Select(p => new ProductViewModel()
			{
				Name = p.Name
			})
			.ToArrayAsync();
	}


	public async Task<ProductViewModel> GetProductAsync(int id)
	{
		var product = await _context.Products
			.FirstOrDefaultAsync(p => p.Id == id);

		var model = new ProductViewModel();

		if (product != null)
		{
			model.Name = product.Name;
		}

		return model;
	}

	public async Task AddProductAsync(ProductViewModel model)
	{
		var product = new Product()
		{
			Name = model.Name
		};

		await _context.Products.AddAsync(product);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateProductAsync(ProductViewModel model, int id)
	{
		if (model == null || model.Id != id)
		{
			throw new ArgumentException("Invalid product");
		}

		var product = await _context.Products
			.FindAsync(id);

		product.Name = model.Name;
	}

	public async Task DeleteProductAsync(int id)
	{
		var product = await _context.Products.FindAsync(id);
		_context.Products.Remove(product);

		await _context.SaveChangesAsync();
	}
}

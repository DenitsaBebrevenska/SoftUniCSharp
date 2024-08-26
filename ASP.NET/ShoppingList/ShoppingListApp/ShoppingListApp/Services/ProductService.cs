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
			.AsNoTracking()
			.Select(p => new ProductViewModel()
			{
				Id = p.Id,
				Name = p.Name
			})
			.ToArrayAsync();
	}


	public async Task<ProductViewModel> GetProductAsync(int id)
	{
		var product = await _context.Products
			.FirstOrDefaultAsync(p => p.Id == id);

		if (product == null)
		{
			throw new ArgumentException("Invalid product");
		}

		var model = new ProductViewModel()
		{
			Id = product.Id,
			Name = product.Name
		};

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

	public async Task UpdateProductAsync(ProductViewModel model)
	{
		var product = await _context.Products
			.FindAsync(model.Id);

		if (model == null)
		{
			throw new ArgumentException("Invalid product");
		}

		product.Name = model.Name;

		await _context.SaveChangesAsync();
	}

	public async Task DeleteProductAsync(int id)
	{
		var product = await _context.Products.FindAsync(id);

		if (product == null)
		{
			throw new ArgumentException("Invalid product");
		}

		_context.Products.Remove(product);
		await _context.SaveChangesAsync();
	}
}

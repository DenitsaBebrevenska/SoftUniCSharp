using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Contracts;
using ShoppingListApp.Models;

namespace ShoppingListApp.Controllers;
public class ProductController : Controller
{
	private readonly IProductService _service;

	public ProductController(IProductService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		var products = await _service.GetProductsAsync();
		return View(products);
	}

	[HttpGet]
	public IActionResult AddProduct()
	{
		var model = new ProductViewModel();
		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> AddProduct(ProductViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}
		await _service.AddProductAsync(model);
		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public async Task<IActionResult> UpdateProduct(int id)
	{
		var model = await _service.GetProductAsync(id);
		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> UpdateProduct(ProductViewModel model, int id)
	{
		if (!ModelState.IsValid || model.Id != id)
		{
			return View(model);
		}
		await _service.UpdateProductAsync(model);
		return RedirectToAction(nameof(Index));
	}

	[HttpPost]
	public async Task<IActionResult> DeleteProduct(int id)
	{
		await _service.DeleteProductAsync(id);
		return RedirectToAction(nameof(Index));
	}
}

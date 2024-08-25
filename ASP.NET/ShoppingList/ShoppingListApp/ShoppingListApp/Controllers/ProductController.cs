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
	public async Task<IActionResult> GetById(int id)
	{
		var product = await _service.GetProductAsync(id);
		return View(product);
	}

	[HttpPost]
	public async Task<IActionResult> AddProduct(ProductViewModel model)
	{
		await _service.AddProductAsync(model);
		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> UpdateProduct(ProductViewModel model)
	{
		await _service.UpdateProductAsync(model, model.Id);
		return RedirectToAction(nameof(Index));
	}

	[HttpPost]
	public async Task<IActionResult> DeleteProduct(int id)
	{
		await _service.DeleteProductAsync(id);
		return RedirectToAction(nameof(Index));
	}
}

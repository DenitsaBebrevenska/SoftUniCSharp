using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Contracts;

namespace ShoppingListApp.Controllers;
public class ProductController : Controller
{
	private readonly IProductService _service;

	public ProductController(IProductService service)
	{
		_service = service;
	}
	public async Task<IActionResult> Index()
	{
		var products = await _service.GetProductsAsync();
		return View(products);
	}
}

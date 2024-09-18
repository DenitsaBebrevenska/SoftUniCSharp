using CoffeeShop.Contracts;
using CoffeeShop.Hubs;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoffeeShop.Controllers;
public class CoffeeController : Controller
{
	private readonly IOrderService _orderService;
	private readonly IHubContext<CoffeeHub> _hubContext;

	public CoffeeController(IOrderService orderService,
		IHubContext<CoffeeHub> hubContext)
	{
		_orderService = orderService;
		_hubContext = hubContext;
	}

	public IActionResult Index()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> OrderCoffee([FromBody] Order order)
	{
		await _hubContext.Clients.All.SendAsync("NewOrder", order);
		var orderId = _orderService.NewOrder();
		return Accepted(orderId);
	}
}

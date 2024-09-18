using CoffeeShop.Contracts;
using CoffeeShop.Models;
using Microsoft.AspNetCore.SignalR;

namespace CoffeeShop.Hubs;

public class CoffeeHub : Hub
{
	private readonly IOrderService _orderService;

	public CoffeeHub(IOrderService orderService)
	{
		_orderService = orderService;
	}

	public async Task GetUpdateForOrder(int id)
	{
		CheckResult result;

		do
		{
			result = _orderService.GetUpdate(id);

			if (result.New)
			{
				await Clients.Caller.SendAsync("ReceiveOrderUpdate", result.Update);
			}

		} while (!result.Finished);

		await Clients.Caller.SendAsync("Finished");
	}
}

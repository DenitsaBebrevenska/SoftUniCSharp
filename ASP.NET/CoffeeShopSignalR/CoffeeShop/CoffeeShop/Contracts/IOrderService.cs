using CoffeeShop.Models;

namespace CoffeeShop.Contracts;

public interface IOrderService
{
	public CheckResult GetUpdate(int id);

	public int NewOrder();
}

using CoffeeShop.Contracts;
using CoffeeShop.Models;

namespace CoffeeShop.Services;

public class OrderService : IOrderService
{
	private readonly string[] _status =
	{
		"Grinding beans",
		"Steaming milk",
		"Quality control",
		"Delivering...",
		"Picked up"
	};

	private readonly Random _random;
	private readonly List<int> _indexes;

	public OrderService()
	{
		_random = new Random();
		_indexes = new List<int>();
	}

	public CheckResult GetUpdate(int id)
	{
		Thread.Sleep(1000);
		var index = _indexes[id - 1];

		if (_random.Next(0, 4) == 2)
		{
			if (_status.Length > _indexes[id - 1])
			{
				var result = new CheckResult()
				{
					New = true,
					Update = _status[index],
					Finished = _status.Length - 1 == index
				};

				_indexes[id - 1]++;
				return result;
			}
		}

		return new CheckResult { New = false };
	}

	public int NewOrder()
	{
		_indexes.Add(0);
		return _indexes.Count;
	}
}

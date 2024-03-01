namespace AndreyAndBilliard
{
	internal class Program
	{
		static void Main()
		{
			byte numberOfEntries = byte.Parse(Console.ReadLine());
			Dictionary<string, decimal> itemsForSale = PopulateItemMap(numberOfEntries);
			List<Customer> customersList = new List<Customer>();

			string input;

			while ((input = Console.ReadLine()) != "end of clients")
			{
				string[] orderArgs = input.Split(new char[] { ',', '-' });
				string customerName = orderArgs[0];
				string itemName = orderArgs[1];
				int itemQuantity = int.Parse(orderArgs[2]);

				if (!itemsForSale.ContainsKey(itemName))
				{
					continue;
				}

				Customer customer = customersList.FirstOrDefault(c => c.Name == customerName);

				if (customer == null)
				{
					customersList.Add(new Customer()
					{
						Name = customerName,
						ItemsBought = new Dictionary<string, int>()
						{
							{itemName, itemQuantity}
						}
					});
				}
				else
				{
					if (!customer.ItemsBought.ContainsKey(itemName))
					{
						customer.ItemsBought.Add(itemName, itemQuantity);
					}
					else
					{
						customer.ItemsBought[itemName] += itemQuantity;
					}
				}
			}

			PrintResult(itemsForSale, customersList);
		}

		static void PrintResult(Dictionary<string, decimal> itemsForSale, List<Customer> customersList)
		{
			foreach (Customer customer in customersList.OrderBy(c => c.Name))
			{
				Console.WriteLine(customer.Name);
				foreach (var kvp in customer.ItemsBought)
				{
					customer.Bill += itemsForSale[kvp.Key] * kvp.Value;
					Console.WriteLine($"-- {kvp.Key} - {kvp.Value}");
				}

				Console.WriteLine($"Bill: {customer.Bill:F2}");
				
			}

			Console.WriteLine($"Total bill: {customersList.Sum(c => c.Bill):F2}");
		}

		static Dictionary<string, decimal> PopulateItemMap(byte numberOfEntries)
		{
			Dictionary<string, decimal> itemsForSale = new Dictionary<string, decimal>();

			for (byte i = 0; i < numberOfEntries; i++)
			{
				string[] itemArgs = Console.ReadLine().Split('-');
				string itemName = itemArgs[0];
				decimal itemPrice = decimal.Parse(itemArgs[1]);

				if (!itemsForSale.ContainsKey(itemName))
				{
					itemsForSale.Add(itemName, itemPrice);
					continue;
				}

				itemsForSale[itemName] = itemPrice;
			}

			return itemsForSale;
		}
	}
}

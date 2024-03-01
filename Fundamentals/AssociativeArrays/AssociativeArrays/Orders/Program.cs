namespace Orders
{
	internal class Program
	{
		static void Main()
		{
			string input;
			Dictionary<string, ProductInfo> orders = new Dictionary<string, ProductInfo>();
			while ((input = Console.ReadLine()) != "buy")
			{
				string[] orderDetails = input.Split();
				string name = orderDetails[0];
				decimal price = decimal.Parse(orderDetails[1]);
				int quantity = int.Parse(orderDetails[2]);
				
				if (!orders.ContainsKey(name))
				{
					orders.Add(name, new ProductInfo(price, quantity));
					continue;
				}

				int newQuantity = orders[name].Quantity + quantity;
				orders[name] = new ProductInfo(price, newQuantity);
			}

			foreach (var kvp in orders)
			{
				Console.WriteLine($"{kvp.Key} -> {kvp.Value.Price * kvp.Value.Quantity:F2}");
			}
		}
	}
}
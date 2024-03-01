namespace SupermarketDatabase
{
	internal class Program
	{
		static void Main()
		{
			List<Product> products = new List<Product>();
			string input;

			while ((input = Console.ReadLine()) != "stocked")
			{
				string[] productDetails = input.Split();
				string name = productDetails[0];
				decimal price = decimal.Parse(productDetails[1]);
				uint quantity = uint.Parse(productDetails[2]);

				Product product = products.FirstOrDefault(p => p.Name == name);

				if (product == null)
				{
					products.Add(new Product(name, price, quantity));
					continue;
				}

				product.Price = price;
				product.Quantity += quantity;
			}

			decimal totalMoneyAll = 0;

			foreach (Product product in products)
			{
				Console.WriteLine($"{product.Name}: ${product.Price:F2} * {product.Quantity} = ${product.TotalMoney:F2}");
				totalMoneyAll += product.TotalMoney;
			}

			Console.WriteLine("------------------------------");
			Console.WriteLine($"Grand Total: ${totalMoneyAll:F2}");
		}
	}
}

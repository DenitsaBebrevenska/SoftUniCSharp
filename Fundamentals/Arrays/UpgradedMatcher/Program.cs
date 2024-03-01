namespace UpgradedMatcher
{
	internal class Program
	{
		static void Main()
		{
			string[] products = Console.ReadLine().Split();
			long[] quantity = Console.ReadLine().Split().Select(long.Parse).ToArray();
			decimal[] price = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
			string input;

			while ((input = Console.ReadLine()) != "done")
			{
				string[] productArgs = input.Split();
				string product = productArgs[0];
				int indexArrays = Array.IndexOf(products, product);
				decimal priceProduct = price[indexArrays];
				long quantityProduct;
				if (indexArrays > quantity.Length - 1)
				{
					quantityProduct = 0;
				}
				else
				{
					quantityProduct = quantity[indexArrays];	
				}

				long orderedQuantity = long.Parse(productArgs[1]);

				if (orderedQuantity > quantityProduct)
				{
					Console.WriteLine($"We do not have enough {productArgs[0]}");
					continue;
				}
				
				Console.WriteLine($"{product} x {orderedQuantity} costs {orderedQuantity * priceProduct:F2}");
				quantity[indexArrays] -= orderedQuantity;
			}
		}
	}
}

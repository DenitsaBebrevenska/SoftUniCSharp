namespace ComputerStore
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			double sum = 0;
			while (input != "regular" && input != "special")
			{
				double currentPrice = double.Parse(input);
				if (currentPrice < 0)
				{
					Console.WriteLine("Invalid price!");
				}
				else
				{
					sum += currentPrice;
				}
				input = Console.ReadLine();
			}

			if (sum == 0)
			{
				Console.WriteLine("Invalid order!");
				return;
			}

			double totalPrice = sum * 1.2;

			if (input == "special")
			{
				totalPrice *= 0.9;
			}
			PrintReceipt(sum, totalPrice);
		}

		static void PrintReceipt(double sum, double totalPrice)
		{
			Console.WriteLine("Congratulations you've just bought a new computer!");
			Console.WriteLine($"Price without taxes: {sum:F2}$");
			Console.WriteLine($"Taxes: {sum * 0.2 :F2}$");
			Console.WriteLine("-----------");
			Console.WriteLine($"Total price: {totalPrice:F2}$");
			
		}
	}
}
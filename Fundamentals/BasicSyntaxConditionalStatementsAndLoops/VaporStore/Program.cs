namespace VaporStore
{
	internal class Program
	{
		static void Main()
		{
			decimal budget = decimal.Parse(Console.ReadLine());
			decimal balance = budget;
			string input;

			while ((input = Console.ReadLine()) != "Game Time")
			{
				decimal gamePrice = GetGamePrice(input);

				if (gamePrice == 0)
				{
					Console.WriteLine("Not Found");
					continue;
				}

				if (balance - gamePrice == 0)
				{
					balance -= gamePrice;
					Console.WriteLine("Out of money!");
					break;
				}

				if (balance - gamePrice < 0)
				{
					Console.WriteLine("Too Expensive");
					continue;
				}

				balance -= gamePrice;
				Console.WriteLine($"Bought {input}");
			}

			if (balance != 0)
			{
				Console.WriteLine($"Total spent: ${budget - balance:F2}. Remaining: ${balance:F2}");
			}
		}

		static decimal GetGamePrice(string input)
		{
			decimal gamePrice;
			switch (input)
			{
				case "OutFall 4":
					gamePrice = 39.99m;
					break;
				case "CS: OG":
					gamePrice = 15.99m;
					break;
				case "Zplinter Zell":
					gamePrice = 19.99m;
					break;
				case "Honored 2":
					gamePrice = 59.99m;
					break;
				case "RoverWatch":
					gamePrice = 29.99m;
					break;
				case "RoverWatch Origins Edition":
					gamePrice = 39.99m;
					break;
				default:
					return 0;
			}
			return gamePrice;
		}
	}
}
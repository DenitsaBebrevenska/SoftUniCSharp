namespace GamingStore
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double budget = double.Parse(Console.ReadLine());
			double outFall4Price = 39.99;
			double csOgPrice = 15.99;
			double zplinterZellPrice = 19.99;
			double honored2Price = 59.99;
			double roverWatchPrice = 29.99;
			double roverWatchOriginsPrice = 39.99;
			bool outOfMoney = false;
			double currentBalance = budget;
			string input = Console.ReadLine();

			while (input != "Game Time")
			{
				if (input == "OutFall 4")
				{
					if (currentBalance >= outFall4Price)
					{
						Console.WriteLine("Bought OutFall 4");
						currentBalance -= outFall4Price;
						if (currentBalance == 0)
						{
							PrintOutOfMoney();
							outOfMoney = true;
							break;
						}
					}
					else { PrintExpensive(); }
				}
				else if (input == "CS: OG")
				{
					if (currentBalance >= csOgPrice)
					{
						Console.WriteLine("Bought CS: OG");
						currentBalance -= csOgPrice;
						if (currentBalance == 0)
						{
							PrintOutOfMoney();
							outOfMoney = true;
							break;
						}
					}
					else { PrintExpensive(); }
				}
				else if (input == "Zplinter Zell")
				{
					if (currentBalance >= zplinterZellPrice)
					{
						Console.WriteLine("Bought Zplinter Zell");
						currentBalance -= zplinterZellPrice;
						if (currentBalance == 0)
						{
							PrintOutOfMoney();
							outOfMoney = true;
							break;
						}
					}
					else { PrintExpensive(); }
				}
				else if (input == "Honored 2")
				{
					if (currentBalance >= honored2Price)
					{
						Console.WriteLine("Bought Honored 2");
						currentBalance -= honored2Price;
						if (currentBalance == 0)
						{
							PrintOutOfMoney();
							outOfMoney = true;
							break;
						}
					}
					else { PrintExpensive(); }
				}
				else if (input == "RoverWatch")
				{
					if (currentBalance >= roverWatchPrice)
					{
						Console.WriteLine("Bought RoverWatch");
						currentBalance -= roverWatchPrice;
						if (currentBalance == 0)
						{
							PrintOutOfMoney();
							outOfMoney = true;
							break;
						}
					}
					else { PrintExpensive(); }
				}
				else if (input == "RoverWatch Origins Edition")
				{
					if (currentBalance >= roverWatchOriginsPrice)
					{
						Console.WriteLine("Bought RoverWatch Origins Edition");
						currentBalance -= roverWatchOriginsPrice;
						if (currentBalance == 0)
						{
							PrintOutOfMoney();
							outOfMoney = true;
							break;
						}
					}
					else { PrintExpensive(); }
				}
				else
				{
					Console.WriteLine("Not Found");
                }
				input = Console.ReadLine();
			}
			if (!outOfMoney)
			{
				Console.WriteLine($"Total spent: ${budget - currentBalance:F2}. Remaining: ${currentBalance:F2}");
			}
        }
		static void PrintExpensive()
		{
            Console.WriteLine("Too Expensive");
        }
		static void PrintOutOfMoney()
		{
			Console.WriteLine("Out of money!");
			
		}
	}
}
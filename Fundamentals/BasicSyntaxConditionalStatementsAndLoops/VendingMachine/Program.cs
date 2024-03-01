using System.Runtime.InteropServices;

namespace VendingMachine
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			double sum = 0;
			double priceNuts = 2, priceCoke = 1, priceWater = 0.7, priceCrisps = 1.5, priceSoda = 0.8;
			while (input != "Start")
			{
				double currentCoins = double.Parse(input);
				
				if (currentCoins == 0.1 || currentCoins == 0.2 || currentCoins == 0.5 || currentCoins == 1 || currentCoins == 2)
				{
					sum += currentCoins;
				}
				else
				{
					Console.WriteLine($"Cannot accept {currentCoins}");
				}
				input = Console.ReadLine();
			}
			string secondInput = Console.ReadLine();
			bool moneySuffice = true;
			while (secondInput != "End")
			{
				if (secondInput == "Nuts")
				{
					if (sum >= priceNuts)
					{
						Console.WriteLine("Purchased nuts");
						sum -= priceNuts;
					}
					else
					{
						moneySuffice = false;
					}

				}
				else if (secondInput == "Water")
				{
					if (sum >= priceWater)
					{
						Console.WriteLine("Purchased water");
						sum -= priceWater;
					}
					else
					{
						moneySuffice = false;
					}
				}
				else if (secondInput == "Crisps")
				{
					if (sum >= priceCrisps)
					{
						Console.WriteLine("Purchased crisps");
						sum -= priceCrisps;
					}
					else
					{
						moneySuffice = false;
					}
				}
				else if (secondInput == "Soda")
				{
					if (sum >= priceSoda)
					{
						Console.WriteLine("Purchased soda");
						sum -= priceSoda;
					}
					else
					{
						moneySuffice = false;
					}
				}
				else if (secondInput == "Coke")
				{
					if (sum >= priceCoke)
					{
						Console.WriteLine("Purchased coke");
						sum -= priceCoke;
					}
					else
					{
						moneySuffice = false;
					}
				}
				else
				{
                    Console.WriteLine("Invalid product");
                }
				if (!moneySuffice)
				{
					Console.WriteLine("Sorry, not enough money");
				}
				secondInput = Console.ReadLine();
			}
            Console.WriteLine($"Change: {sum:F2}");
        }
		
	}
}
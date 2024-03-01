namespace VendingMachineMethods
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string inputCoins = Console.ReadLine();
			double balance = 0;
			while (inputCoins != "Start")
			{
				double coins = double.Parse(inputCoins);
				double coinsToAdd = CheckCoins(coins);
				balance += coinsToAdd;
				inputCoins = Console.ReadLine();
			}
            string inputProduct = Console.ReadLine();
			while (inputProduct != "End")
			{
				double productPrice = CheckProduct(inputProduct);
				if (productPrice <= balance && productPrice != 0) //this looks kinda stupid, don`t know if it well done
				{
                    Console.WriteLine($"Purchased {inputProduct.ToLower()}");
					balance -= productPrice;
                }
				else
				{
					if (productPrice > balance)
					{
						Console.WriteLine("Sorry, not enough money");
					}
                }
				inputProduct = Console.ReadLine();
			}
            Console.WriteLine($"Change: {balance:F2}");
        }
		static double CheckCoins(double coins)
		{
			if (coins != 0.1 && coins != 0.2 && coins != 0.5 && coins != 1 && coins != 2)
			{
                Console.WriteLine($"Cannot accept {coins}");
				return 0;
            }
			return coins;
		}
		static double CheckProduct(string product)
		{
			if (product == "Nuts")
			{
				return 2.0;
			}
			else if (product == "Water")
			{
				return 0.7;
			}
			else if (product == "Crisps")
			{
				return 1.5;
			}
			else if (product == "Soda")
			{
				return 0.8;
			}
			else if (product == "Coke")
			{
				return 1.0;
			}
			else
			{
                Console.WriteLine("Invalid product");
                return 0;
			}
		}
		
	}
}
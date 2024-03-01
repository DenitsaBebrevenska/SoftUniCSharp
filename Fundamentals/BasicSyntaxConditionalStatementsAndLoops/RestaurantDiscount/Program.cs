namespace RestaurantDiscount
{
	internal class Program
	{
		static void Main()
		{
			int groupSize = int.Parse(Console.ReadLine());
			string package = Console.ReadLine();
			double discount = 0;
			double pricePackage = 0;

			if (package == "Normal")
			{
				discount = 0.95;
				pricePackage = 500;
			}
			else if (package == "Gold")
			{
				discount = 0.9;
				pricePackage = 750;
			}
			else
			{
				discount = 0.85;
				pricePackage = 1000;
			}

			string suitableHall = string.Empty;
			int hallPrice = 0;
			if (groupSize <= 50)
			{
				suitableHall = "Small Hall";
				hallPrice = 2500;
			}
			else if (groupSize <= 100)
			{
				suitableHall = "Terrace";
				hallPrice = 5000;
			}
			else if (groupSize <= 120)
			{
				suitableHall = "Great Hall";
				hallPrice = 7500;
			}
			else
			{
				Console.WriteLine("We do not have an appropriate hall."); 
				return;
			}

			double pricePerPerson = ((pricePackage + hallPrice) * discount) / groupSize;
			Console.WriteLine($"We can offer you the {suitableHall}");
			Console.WriteLine($"The price per person is {pricePerPerson:F2}$");

		}
	}
}
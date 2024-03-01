namespace Hotel
{
	internal class Program
	{
		static void Main()
		{
			string month = Console.ReadLine();
			int nights = int.Parse(Console.ReadLine());

			double priceStudio = 0, priceDouble = 0, priceSuite = 0;
			if (month == "May" || month == "October")
			{
				priceStudio = nights * 50;
				priceDouble = nights * 65;
				priceSuite = nights * 75;

				if (nights > 7 && month == "October")
				{
					priceStudio = (nights - 1) * 50;
				}

				if (nights > 7)
				{
					priceStudio *= 0.95;
				}
			}
			else if (month == "June" || month == "September")
			{
				priceStudio = nights * 60;
				priceDouble = nights * 72;
				priceSuite = nights * 82;
				if (nights > 7 && month == "September")
				{
					priceStudio = (nights - 1) * 60;
				}
				if (nights > 14)
				{
					priceDouble *= 0.9;
				}
				
			}
			else
			{
				priceStudio = nights * 68;
				priceDouble = nights * 77;
				priceSuite = nights * 89;
				if (nights > 14)
				{
					priceSuite *= 0.85;
				}
			}
			
			Console.WriteLine($"Studio: {priceStudio:F2} lv.");
			Console.WriteLine($"Double: {priceDouble:F2} lv.");
			Console.WriteLine($"Suite: {priceSuite:F2} lv.");
		}
	}
}
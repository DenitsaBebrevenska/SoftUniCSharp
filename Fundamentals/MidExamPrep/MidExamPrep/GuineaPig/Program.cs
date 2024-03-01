namespace GuineaPig
{
	internal class Program
	{
		static void Main()
		{
			//in kilograms ! 1 kg = 1000 gr
			double foodQuantity = double.Parse(Console.ReadLine()) * 1000;
			double hayQuantity = double.Parse(Console.ReadLine()) * 1000;
			double coverQuantity = double.Parse(Console.ReadLine()) * 1000;
			double petWeight = double.Parse(Console.ReadLine()) * 1000;

			int daysCounter = 0;
			while (ProvisionsSuffice(foodQuantity, hayQuantity, coverQuantity))
			{
				daysCounter++;
				foodQuantity -= 300;
				if (daysCounter % 2 == 0)
				{
					double hayUsed = foodQuantity * 0.05;
					hayQuantity -= hayUsed;
				}

				if (daysCounter % 3 == 0)
				{
					double coverUsed = petWeight / 3;
					coverQuantity -= coverUsed;
				}

				if (daysCounter == 30)
				{
					break;
				}
			}
			PrintResult(foodQuantity, hayQuantity, coverQuantity);
		}

		static void PrintResult(double foodQuantity, double hayQuantity, double coverQuantity)
		{
			if (ProvisionsSuffice(foodQuantity, hayQuantity, coverQuantity))
			{
				Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodQuantity / 1000 :F2}," +
				                  $" Hay: {hayQuantity / 1000 :F2}, Cover: {coverQuantity / 1000 :F2}.");
			}
			else
			{
				Console.WriteLine("Merry must go to the pet store!");
			}
		}

		static bool ProvisionsSuffice(double foodQuantity, double hayQuantity, double coverQuantity)
		{
			return foodQuantity > 0 && hayQuantity > 0 && coverQuantity > 0;
		}
	}
}
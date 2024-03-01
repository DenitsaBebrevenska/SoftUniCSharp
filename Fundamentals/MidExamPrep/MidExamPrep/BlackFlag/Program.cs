namespace BlackFlag
{
	internal class Program
	{
		static void Main()
		{
			int days = int.Parse(Console.ReadLine());
			double dailyPlunder = double.Parse(Console.ReadLine());
			double expectedPlunder = double.Parse(Console.ReadLine());

			double totalPlunder = 0;
		
			for (int i = 1; i <= days; i++)
			{
				
				if (i % 3 == 0)
				{
					totalPlunder += dailyPlunder * 0.5;
				}

				totalPlunder += dailyPlunder;

				if (i % 5 == 0)
				{
					totalPlunder -= totalPlunder * 0.3;
				}

			}

			PrintResult(totalPlunder, expectedPlunder);
		}

		static void PrintResult(double totalPlunder, double expectedPlunder)
		{
			Console.WriteLine(totalPlunder >= expectedPlunder ? $"Ahoy! {totalPlunder:F2} plunder gained." :
				$"Collected only {(totalPlunder / expectedPlunder) * 100 :F2}% of the plunder.");
		}
	}
}
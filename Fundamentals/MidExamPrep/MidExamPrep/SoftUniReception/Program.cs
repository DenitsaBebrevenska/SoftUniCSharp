namespace SoftUniReception
{
	internal class Program
	{
		static void Main()
		{
			int capacityFirstEmployee = int.Parse(Console.ReadLine());
			int capacitySecondEmployee = int.Parse(Console.ReadLine());
			int capacityThirdEmployee = int.Parse(Console.ReadLine());
			int studentsCount = int.Parse(Console.ReadLine());
			
			int ratePerHour = capacityFirstEmployee + capacitySecondEmployee + capacityThirdEmployee;

			double neededHours = 0;
			if (studentsCount > 0)
			{
				neededHours = Math.Ceiling(1.0 * studentsCount / ratePerHour);

				int hoursOfBreak = (int)neededHours / 3;
				if (neededHours % 3 == 0)
				{
					hoursOfBreak--;
				}

				neededHours += hoursOfBreak;
			}

			Console.WriteLine($"Time needed: {neededHours}h.");
		}
	}
}
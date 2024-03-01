namespace ConvertSpeedUnits
{
	internal class Program
	{
		static void Main()
		{
			int distanceMeters = int.Parse(Console.ReadLine());
			int hours = int.Parse(Console.ReadLine());
			int minutes = int.Parse(Console.ReadLine());
			int seconds = int.Parse(Console.ReadLine());

			int totalSeconds = hours * 3600 + minutes * 60 + seconds;
			double metersPerSecond = (double)distanceMeters / totalSeconds;
			Console.WriteLine($"{metersPerSecond:F6}");

			double kilometers = (double)distanceMeters / 1000;
			double totalHours = hours + ((double)minutes / 60) + ((double)seconds / 3600);
			double kilometersPerHour = kilometers / totalHours;
			Console.WriteLine($"{kilometersPerHour:F6}");

			//Assume 1 mile = 1609 meters.
			double distanceMiles = (double)distanceMeters / 1609;
			double milesPerHour = distanceMiles/ totalHours;
			Console.WriteLine($"{milesPerHour:F6}");

		}
	}
}
namespace SinoTheWalker
{
	internal class Program
	{
		static void Main()
		{
			//86400 seconds = 1 day
			DateTime departureTime = DateTime.Parse(Console.ReadLine());
			long numberOfSteps = long.Parse(Console.ReadLine()) % 86400;;
			long secondsPerStep = long.Parse(Console.ReadLine()) % 86400;;

			long elapsedTime = numberOfSteps * secondsPerStep;

			TimeSpan timeToAdd= TimeSpan.FromSeconds(elapsedTime);
			DateTime newTime = departureTime.Add(timeToAdd);
			string time = $"{newTime.Hour:D2}:{newTime.Minute:D2}:{newTime.Second:D2}";
			Console.WriteLine($"Time Arrival: {time}");
		}
	}
}
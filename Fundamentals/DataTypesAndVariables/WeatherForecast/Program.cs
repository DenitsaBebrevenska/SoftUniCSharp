namespace WeatherForecast
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();

			if (input.Contains("."))
			{
				Console.WriteLine("Rainy");
				return;
			}

			long number = long.Parse(input);

			if (number >= sbyte.MinValue && number <= sbyte.MaxValue)
			{
				Console.WriteLine("Sunny");
			}
			else if (number >= int.MinValue && number <= int.MaxValue)
			{
				Console.WriteLine("Cloudy");
			}
			else
			{
				Console.WriteLine("Windy");
			}
		}
	}
}
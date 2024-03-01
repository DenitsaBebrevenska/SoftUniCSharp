namespace TemperatureConversion
{
	internal class Program
	{
		static void Main()
		{
			double fahrenheitTemperature = double.Parse(Console.ReadLine());
			double celsiusTemperature = ConvertToCelsius(fahrenheitTemperature);
			Console.WriteLine($"{celsiusTemperature:F2}");
		}

		static double ConvertToCelsius(double fahrenheitTemperature)
		{
			return (fahrenheitTemperature - 32) * 5 / 9;
		}
	}
}
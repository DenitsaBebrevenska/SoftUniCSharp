using System.Text.RegularExpressions;

namespace Weather
{
	internal class Program
	{
		static void Main()
		{
			List<Weather> forecast = new List<Weather>();
			string input;
			string pattern = @"(?<city>[A-Z]{2})(?<temperature>\d{1,2}.\d{1,2})(?<type>[A-Za-z]+)\|";

			while ((input = Console.ReadLine()) != "end")
			{
				Match matchForecast = Regex.Match(input, pattern);

				if (!matchForecast.Success)
				{
					continue;
				}

				string cityName = matchForecast.Groups["city"].Value;
				double temperature = double.Parse(matchForecast.Groups["temperature"].Value);
				string weatherType = matchForecast.Groups["type"].Value;

				Weather weather = forecast.FirstOrDefault(w => w.City == cityName);

				if (weather == null)
				{
					weather = new Weather(cityName, temperature, weatherType);
					forecast.Add(weather);
					continue;
				}

				weather.AverageTemperature = temperature;
				weather.Type = weatherType;
			}

			foreach (Weather weather in forecast.OrderBy(w => w.AverageTemperature))
			{
				Console.WriteLine(weather);
			}
		}
	}
}

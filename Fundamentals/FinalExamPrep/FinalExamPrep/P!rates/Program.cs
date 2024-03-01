namespace P_rates
{
	internal class Program
	{
		static void Main()
		{
			List<City> cities = PopulateCitiesList();

			string input;
			while ((input = Console.ReadLine()) != "End")
			{
				string[] actionDetails = input.Split("=>");
				string action= actionDetails[0];
				string cityName = actionDetails[1];
				City city = cities.FirstOrDefault(x => x.Name == cityName);

				if (action == "Plunder")
				{
					PlunderCity(actionDetails, city, cities);
				}
				else //Prosper
				{
					IncreaseGold(actionDetails, city);
				}
				
			}
			Console.WriteLine(cities.Count == 0 ? "Ahoy, Captain! All targets have been plundered and destroyed!" : 
				$"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:\n{string.Join("\n", cities)}");
		}

		static List<City> PopulateCitiesList()
		{
			List<City> cities = new List<City>();
			string input;
			while ((input = Console.ReadLine()) != "Sail")
			{
				string[] cityDetails = input.Split("||");
				string cityName = cityDetails[0];
				int population = int.Parse(cityDetails[1]);
				int gold = int.Parse(cityDetails[2]);
				City city = cities.FirstOrDefault(x => x.Name == cityName);

				if (city != null)
				{
					city.Gold += gold;
					city.Population += population;
					continue;
				}

				cities.Add(new City(cityName, population, gold));
			}
			return cities;
		}

		static void PlunderCity(string[] actionDetails, City city, List<City> cities)
		{
			int peopleKilled = int.Parse(actionDetails[2]);
			int goldStolen = int.Parse(actionDetails[3]);
			city.Gold -= goldStolen;
			city.Population -= peopleKilled;
			Console.WriteLine($"{city.Name} plundered! {goldStolen} gold stolen, {peopleKilled} citizens killed.");

			if (city.Gold == 0 || city.Population == 0)
			{
				Console.WriteLine($"{city.Name} has been wiped off the map!");
				cities.Remove(city);
			}
		}

		static void IncreaseGold(string[] actionDetails, City city)
		{
			int goldIncrease = int.Parse(actionDetails[2]);
			if (goldIncrease < 0)
			{
				Console.WriteLine("Gold added cannot be a negative number!");
				return;
			}

			city.Gold += goldIncrease;
			Console.WriteLine($"{goldIncrease} gold added to the city treasury. {city.Name} now has {city.Gold} gold.");
		}
	}
}
namespace PopulationCounter
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<string, List<City>> populationMap = new Dictionary<string, List<City>>();
			string input;
			//city|country|population

			while ((input = Console.ReadLine()) != "report")
			{
				string[] tokens = input.Split('|');
				string city = tokens[0];
				string country = tokens[1];
				long population = long.Parse(tokens[2]);

				if (!populationMap.ContainsKey(country))
				{
					populationMap.Add(country, new List<City>());
				}
				
				populationMap[country].Add(new City(city, population));
			}

			foreach (var kvp in populationMap.
				         OrderByDescending(x => x.Value.Sum(c => c.Population)))
			{
				long sumPopulation = kvp.Value.Sum(x => x.Population);
				Console.WriteLine($"{kvp.Key} (total population: {sumPopulation})");

				foreach (City c in kvp.Value.OrderByDescending(x => x.Population))
				{
					Console.WriteLine($"=>{c.Name}: {c.Population}");
				}
			}
		}
	}
}

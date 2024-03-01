namespace PlantDiscovery
{
	internal class Program
	{
		static void Main()
		{
			int numberOfLines = int.Parse(Console.ReadLine());
			List<Plant> plants = PopulateInitialList(numberOfLines);
			string input;

			while ((input = Console.ReadLine()) != "Exhibition")
			{
				string[] commandDetails = input.Split(new char[] {' ', ':','-'}, StringSplitOptions.RemoveEmptyEntries);
				Plant plant = plants.FirstOrDefault(x => x.Name == commandDetails[1]);

				if (plant == null)
				{
					Console.WriteLine("error");
					continue;
				}
				
				switch (commandDetails[0])
				{
					case "Rate":
						plant.Rating.Add(double.Parse(commandDetails[2]));
						break;
					case "Update":
						plant.Rarity = int.Parse(commandDetails[2]);
						break;
					case "Reset":
						plant.Rating.RemoveRange(0, plant.Rating.Count);
						break;
				}
			}

			Console.WriteLine("Plants for the exhibition:");
			foreach (Plant plant in plants)
			{
				Console.Write(plant);
			}
		}

		static List<Plant> PopulateInitialList(int numberOfLines)
		{
			List<Plant> plants = new List<Plant>();
			for (int i = 0; i < numberOfLines; i++)
			{
				string[] plantDetails = Console.ReadLine().Split("<->");
				string plantName = plantDetails[0];
				int rarity = int.Parse(plantDetails[1]);
				Plant plant = plants.FirstOrDefault(x => x.Name == plantName);
				if (plant != null)
				{
					plant.Rarity = rarity;
					continue;
				}

				plants.Add(new Plant(plantName, rarity));
			}
			return plants;
		}
	}
}
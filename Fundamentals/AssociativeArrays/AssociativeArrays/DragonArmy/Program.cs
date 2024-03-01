namespace DragonArmy
{
	internal class Program
	{
		static void Main()
		{
			int numberOfDragons = int.Parse(Console.ReadLine());

			Dictionary<string, List<Dragon>> dragonDictionary = new Dictionary<string, List<Dragon>>();

			for (int i = 0; i < numberOfDragons; i++)
			{
				string[] dragonDetails = Console.ReadLine().Split();
				string color = dragonDetails[0];
				string name = dragonDetails[1];
				string damageString = dragonDetails[2];
				string healthString = dragonDetails[3];
				string armorString = dragonDetails[4];

				int damage = damageString == "null" ? 45 : int.Parse(damageString);
				int health = healthString == "null" ? 250 : int.Parse(healthString);
				int armor = armorString == "null" ? 10 : int.Parse(armorString);

				if (!dragonDictionary.ContainsKey(color))
				{
					dragonDictionary.Add(color, new List<Dragon>());
				}

				List<Dragon> currentList = dragonDictionary[color];

				Dragon dragon = currentList.FirstOrDefault(d => d.Name == name);

				if (dragon != null)
				{
					dragon.Armor = armor;
					dragon.Health = health;
					dragon.Damage = damage;
					continue;
				}

				currentList.Add(new Dragon(name, damage, health, armor));
			}

			PrintDragons(dragonDictionary);
		}

		static void PrintDragons(Dictionary<string, List<Dragon>> dragonDictionary)
		{
			foreach (var kvp in dragonDictionary)
			{
				List<Dragon> currentList = kvp.Value;
				double averageDamage = (double)currentList.Sum(d => d.Damage) / currentList.Count;
				double averageHealth = (double)currentList.Sum(d => d.Health) / currentList.Count;
				double averageArmor = (double)currentList.Sum(d => d.Armor) / currentList.Count;
				Console.WriteLine($"{kvp.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

				foreach (Dragon dragon in currentList.OrderBy(d => d.Name))
				{
					Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
				}
			}
		}
	}
}
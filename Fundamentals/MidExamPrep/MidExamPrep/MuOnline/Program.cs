namespace MuOnline
{
	internal class Program
	{
		static void Main()
		{
			int health = 100;
			int coins = 0;

			string[] dungeon = Console.ReadLine().Split('|').ToArray();

			for (int i = 0; i < dungeon.Length; i++)
			{
				string[] tokens = dungeon[i].Split();
				string action = tokens[0];
				int value = int.Parse(tokens[1]);

				if (action == "potion")
				{
					health = Healing(health, value);
				}
				else if (action == "chest")
				{
					coins += value;
					Console.WriteLine($"You found {value} bitcoins.");
				}
				else //fight
				{
					health -= value;
					if (health > 0)
					{
						Console.WriteLine($"You slayed {action}.");
					}
					else
					{
						Console.WriteLine($"You died! Killed by {action}.");
						Console.WriteLine($"Best room: {i + 1}");
						return;
					}
				}
			}

			Console.WriteLine("You've made it!");
			Console.WriteLine($"Bitcoins: {coins}");
			Console.WriteLine($"Health: {health}");
		}

		static int Healing(int health, int value)
		{
			int amountHealed;
			if (health + value > 100)
			{
				amountHealed = 100 - health;
			}
			else
			{
				amountHealed = value;
			}

			Console.WriteLine($"You healed for {amountHealed} hp.");

			health += amountHealed;

			Console.WriteLine($"Current health: {health} hp.");
			return health;
		}
	}
}
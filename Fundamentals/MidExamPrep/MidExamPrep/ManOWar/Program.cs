namespace ManOWar
{
	internal class Program
	{
		static void Main()
		{
			int[] pirateShip = ReadInput();
			int[] warship = ReadInput();
			int maxHpPerSection = int.Parse(Console.ReadLine());

			string input;
			while ((input = Console.ReadLine()) != "Retire")
			{
				string[] tokens = input.Split().ToArray();
				int value1;
				int value2;
				if (tokens[0] == "Fire" && IsInArraysRange(warship, (value1 = int.Parse(tokens[1]))))
				{
					warship[value1] -= int.Parse(tokens[2]);
					if (warship[value1] <= 0)
					{
						Console.WriteLine("You won! The enemy ship has sunken.");
						return;
					}
				}
				else if (tokens[0] == "Defend" && IsInArraysRange(pirateShip, (value1 = int.Parse(tokens[1]))) &&
						 IsInArraysRange(pirateShip, (value2 = int.Parse(tokens[2]))))
				{
					for (int i = value1; i <= value2; i++)
					{
						pirateShip[i] -= int.Parse(tokens[3]);
						if (pirateShip[i] <= 0)
						{
							Console.WriteLine("You lost! The pirate ship has sunken.");
							return;
						}
					}
				}
				else if (tokens[0] == "Repair" && IsInArraysRange(pirateShip, (value1 = int.Parse(tokens[1]))))
				{
					RepairShip(pirateShip, value1, int.Parse(tokens[2]), maxHpPerSection);
				}
				else if (tokens[0] == "Status")
				{
					ReportShipStatus(pirateShip, maxHpPerSection);
				}
			}

			Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
			Console.WriteLine($"Warship status: {warship.Sum()}");
		}

		static bool IsInArraysRange(int[] ship, int index)
		{
			return index >= 0 && index < ship.Length;
		}

		static int[] ReadInput()
		{
			int[] array = Console.ReadLine().
			  Split('>').
			  Select(int.Parse).
			  ToArray();
			return array;	
		}

		static void RepairShip(int[] pirateShip, int index1, int hp, int maxHpPerSection)
		{
			pirateShip[index1] += hp;
			if (pirateShip[index1] > maxHpPerSection)
			{
				pirateShip[index1] = maxHpPerSection;
			}
		}

		static void ReportShipStatus(int[] pirateShip, int maxHpPerSection)
		{
			int count = 0;
			foreach (int section in pirateShip)
			{
				double minimumState = maxHpPerSection * 0.2;
				if (section < minimumState)
				{
					count++;
				}
			}

			Console.WriteLine($"{count} sections need repair.");
		}

	}
}
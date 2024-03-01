namespace TheLift
{
	internal class Program
	{
		static void Main()
		{
			int peopleCount = int.Parse(Console.ReadLine());
			int[] lift = Console.ReadLine().Split().Select(int.Parse).ToArray();

			//max capacity per wagon = 4

			for (int i = 0; i < lift.Length; i++)
			{
				int capacityCab = 4 - lift[i];
					if (capacityCab > 0 && peopleCount >= capacityCab)
					{
						peopleCount -= capacityCab;
						lift[i] = 4;
					}
					else if (capacityCab > 0 && peopleCount < capacityCab)
					{
						lift[i] += peopleCount;
						peopleCount = 0;
						break;
					}
			}
			PrintStatusLift(peopleCount, lift);

		}

		static bool IsLiftFull(int[] lift)
		{
			int freeCabinsCount = 0;
			foreach (int cab in lift)
			{
				if (cab < 4)
				{
					freeCabinsCount++;
				}
			}

			return freeCabinsCount == 0;
		}

		static void PrintStatusLift(int peopleCount, int[] lift)
		{
			if (peopleCount == 0 && !IsLiftFull(lift))
			{
				Console.WriteLine("The lift has empty spots!");
			}
			else if (peopleCount > 0 && IsLiftFull(lift))
			{
				Console.WriteLine($"There isn't enough space! {peopleCount} people in a queue!");
			}
			Console.WriteLine(string.Join(' ', lift));
		}
	}
}
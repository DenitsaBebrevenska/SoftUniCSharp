namespace HeartDelivery
{
	internal class Program
	{
		static void Main()
		{
			int[] neighborhood = Console.ReadLine().
				Split('@').
				Select(int.Parse).
				ToArray();

			string command;
			int currentPosition = 0;
			while ((command = Console.ReadLine()) != "Love!")
			{
				string[] tokens = command.Split(' ').ToArray();
				int jump = int.Parse(tokens[1]);
				currentPosition += jump;

				if (currentPosition > neighborhood.Length - 1)
				{
					currentPosition = 0;
				}

				if (neighborhood[currentPosition] == 0)
				{
					Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
					continue;
				}
				else
				{
					neighborhood[currentPosition] -= 2;
					if (neighborhood[currentPosition] == 0)
					{
						Console.WriteLine($"Place {currentPosition} has Valentine's day." );
					}

				}
			}
			Console.WriteLine($"Cupid's last position was {currentPosition}.");
			PrintCupidSuccess(neighborhood);
		}

		static int GetSuccessfulHouseCount(int[] neighborhood)
		{
			int successCount = 0;
			foreach (int house in neighborhood)
			{
				if (house == 0)
				{
					successCount++;
				}
			}
			return successCount;
		}

		static void PrintCupidSuccess(int[] neighborhood)
		{
			int successfulHouses = GetSuccessfulHouseCount(neighborhood);
			if (successfulHouses == neighborhood.Length)
			{
				Console.WriteLine("Mission was successful.");
			}
			else
			{
				Console.WriteLine($"Cupid has failed {neighborhood.Length - successfulHouses} places.");
			}
		}
	}
}
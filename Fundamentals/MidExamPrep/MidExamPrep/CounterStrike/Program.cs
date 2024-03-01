namespace CounterStrike
{
	internal class Program
	{
		static void Main()
		{
			int energy = int.Parse(Console.ReadLine());

			string input;
			int victoryCount = 0;
			while ((input = Console.ReadLine()) != "End of battle")
			{
				int distance = int.Parse(input);

				if (energy - distance >= 0)
				{
					energy -= distance;
					victoryCount++;
				}
				else
				{
					Console.WriteLine($"Not enough energy! Game ends with {victoryCount} won battles and {energy} energy");
					return;
				}

				if (victoryCount % 3 == 0)
				{
					energy += victoryCount;
				}
			}

			Console.WriteLine($"Won battles: {victoryCount}. Energy left: {energy}" );
		}
	}
}
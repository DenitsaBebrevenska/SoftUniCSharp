namespace Train
{
	internal class Program
	{
		static void Main()
		{
			List<int> wagons = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();

			int capacityOfWagon = int.Parse(Console.ReadLine());

			string input;

			while ((input = Console.ReadLine()) != "end")
			{
				string[] tokens = input.Split();

				if (tokens[0] == "Add")
				{
					wagons.Add(int.Parse(tokens[1]));
				}
				else
				{
					int incomingPassangers = int.Parse(tokens[0]);

					for (int i = 0; i < wagons.Count; i++)
					{
						if (incomingPassangers <= capacityOfWagon - wagons[i])
						{
							wagons[i] += incomingPassangers;
							break;
						}
					}
				}
			}

            Console.WriteLine(string.Join(' ', wagons));
        }
	}
}
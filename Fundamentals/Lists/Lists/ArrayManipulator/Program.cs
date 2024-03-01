namespace ArrayManipulator
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();

			string command;

			while ((command = Console.ReadLine()) != "print")
			{
				string[] commandArgs = command.Split();

				switch (commandArgs[0])
				{
					case "add":
						short index = short.Parse(commandArgs[1]);
						int element = int.Parse(commandArgs[2]);
						numbers.Insert(index, element);
						break;
					case "addMany":
						index = short.Parse(commandArgs[1]);
						List<int> numbersToInsert = commandArgs.Skip(2).Select(int.Parse).ToList();
						numbers.InsertRange(index, numbersToInsert);
						break;
					case "contains":
						element = int.Parse(commandArgs[1]);
						int indexElement = numbers.IndexOf(element);
						Console.WriteLine(indexElement);
						break;
					case "remove":
						index = short.Parse(commandArgs[1]);
						numbers.RemoveAt(index);
						break;
					case "shift":
						int positions = int.Parse(commandArgs[1]);
						for (int i = 0; i < positions; i++)
						{
							int lastElement = numbers[0];
							for (int j = 0; j < numbers.Count - 1; j++)
							{
								numbers[j] = numbers[j + 1];
							}
							numbers[^1] = lastElement;
						}
						break;
					case "sumPairs":
						List<int> sumPairs = new List<int>();

						for (int i = 0; i < numbers.Count; i += 2)
						{
							if (i + 1 == numbers.Count)
							{
								sumPairs.Add(numbers[i]);
								continue;
							}
							sumPairs.Add(numbers[i] + numbers[i + 1]);
						}

						numbers = sumPairs;
						break;
				}
			}
			Console.WriteLine($"[{string.Join(", ", numbers)}]");
		}
	}
}
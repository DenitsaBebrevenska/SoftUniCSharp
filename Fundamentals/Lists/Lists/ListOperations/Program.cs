namespace ListOperations
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();

			string input;
			while ((input = Console.ReadLine()) != "End")
			{
				string[] tokens = input.Split();
				switch (tokens[0])
				{
					case "Add":
						int numberToAdd = int.Parse(tokens[1]);
						numbers.Add(numberToAdd);
						break;
					case "Insert":
						int numberToInsert = int.Parse(tokens[1]);
						int indexInsertion = int.Parse(tokens[2]);

						switch (ValidateIndex(indexInsertion, numbers))
						{
							case true:
								numbers.Insert(indexInsertion, numberToInsert);
								break;
						}
						break;
					case "Remove":
						int indexRemoval = int.Parse(tokens[1]);
						switch (ValidateIndex(indexRemoval, numbers))
						{
							case true:
								numbers.RemoveAt(indexRemoval);
								break;
						}
						break;
					case "Shift":
						string direction = tokens[1];
						int count = int.Parse(tokens[2]);
						numbers = ShiftList(direction, count, numbers);
						break;
				}
			}
            Console.WriteLine(string.Join(' ', numbers));
        }
		static bool ValidateIndex(int index, List<int> numbers)
		{
			if (index >= 0 && index < numbers.Count)
			{
				return true;
			}
			else
			{
				Console.WriteLine("Invalid index");
				return false;
			}
		}
		static List<int> ShiftList(string direction, int count, List<int> numbers)
		{
			if (direction == "left")
			{
				for (int i = 1; i <= count; i++)
				{
				
					numbers.Add(numbers[0]);
					numbers.RemoveAt(0);
				}
			}
			else
			{
				for (int i = 1; i <= count; i++)
				{
					int number = numbers[^1];
					numbers.RemoveAt(numbers.Count - 1);
					numbers.Insert(0, number);
				}
			}
			return numbers;
		}
	}
}
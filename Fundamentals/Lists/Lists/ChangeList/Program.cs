namespace ChangeList
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

			while ((input = Console.ReadLine()) != "end")
			{
				string[] tokens = input.Split();

				switch (tokens[0])
				{
					case "Delete":
						int numberToDelete = int.Parse(tokens[1]);
						numbers = DeleteElements(numbers, numberToDelete);
						break;
					case "Insert":
						int numberToInsert = int.Parse(tokens[1]);
						int index = int.Parse(tokens[2]);
						numbers.Insert(index, numberToInsert);
						break;
				}
			}

			Console.WriteLine(string.Join(' ', numbers));
		}
		static List<int> DeleteElements(List<int> numbers, int element)
		{
			for (int i = 0; i < numbers.Count; i++)
			{
				if (numbers[i] == element)
				{
					numbers.RemoveAt(i);
				}
			}
			return numbers;
		}
	}
}
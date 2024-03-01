namespace CountNumbers
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<int, int> numberOccurrenceDictionary = new Dictionary<int, int>();
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();

			foreach (int number in numbers)
			{
				if (!numberOccurrenceDictionary.ContainsKey(number))
				{
					numberOccurrenceDictionary.Add(number, 0);
				}

				numberOccurrenceDictionary[number]++;
			}

			foreach (var kvp in numberOccurrenceDictionary.OrderBy(n => n.Key))
			{
				Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
			}
		}
	}
}

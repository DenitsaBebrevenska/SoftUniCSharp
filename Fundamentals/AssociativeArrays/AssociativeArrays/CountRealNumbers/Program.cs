namespace CountRealNumbers
{
	internal class Program
	{
		static void Main()
		{
			double[] numbers = Console.ReadLine().
				Split().
				Select(double.Parse).
				ToArray();
			SortedDictionary<double, int> counts = new SortedDictionary<double, int>();
			foreach (var number in numbers)
			{
				if (!counts.ContainsKey(number))
				{
					counts[number] = 0;
				}
				
				counts[number]++;
			}

			foreach (var kvp in counts)
			{
				Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
			}
		}
	}
}
namespace MostFrequentNumber
{
	internal class Program
	{
		static void Main()
		{
			int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var groups = numbers.GroupBy(x => x);
			var largest = groups.OrderByDescending(x => x.Count()).First();
			Console.WriteLine(largest.Key);
		}
	}
}
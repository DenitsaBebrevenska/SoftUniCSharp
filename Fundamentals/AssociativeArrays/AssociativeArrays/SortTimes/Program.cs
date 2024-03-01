namespace SortTimes
{
	internal class Program
	{
		static void Main()
		{
			List<string> times = Console.ReadLine().Split().ToList();

			times = times.OrderBy(t => t).ToList();

			Console.WriteLine(string.Join(", ", times));
		}
	}
}

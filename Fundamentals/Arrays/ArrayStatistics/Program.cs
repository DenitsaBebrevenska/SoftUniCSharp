namespace ArrayStatistics
{
	internal class Program
	{
		static void Main()
		{
			long[] array = Console.ReadLine().
				Split().
				Select(long.Parse).
				ToArray();
			long min = array.Min();
			long max = array.Max();
			long sum = array.Sum();
			double average = sum * 1.00 / array.Length ;

			Console.WriteLine($"Min = {min}");
			Console.WriteLine($"Max = {max}");
			Console.WriteLine($"Sum = {sum}");
			Console.WriteLine($"Average = {average}");

		}
	}
}

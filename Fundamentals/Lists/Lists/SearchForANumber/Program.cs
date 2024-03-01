namespace SearchForANumber
{
	internal class Program
	{
		static void Main()
		{
			List<int> integers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();
			List<int> extractedIntegers = integers.Take(numbers[0]).ToList();
			extractedIntegers.RemoveRange(0, numbers[1]);

			Console.WriteLine(extractedIntegers.Contains(numbers[2]) ? "YES!" : "NO!");

		}
	}
}

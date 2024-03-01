namespace SortNumbers
{
	internal class Program
	{
		static void Main()
		{
			List<decimal> numbers = Console.ReadLine().
				Split().
				Select(decimal.Parse).
				ToList();

			numbers.Sort();

			Console.WriteLine(string.Join(" <= ", numbers));
		}
	}
}

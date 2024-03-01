namespace OddFilter
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();

			numbers = numbers.Where(n => n % 2 == 0).ToList();
			int averageNumber = (int)numbers.Average();

			foreach (int number in numbers)
			{
				if (number > averageNumber)
				{
					Console.Write(number + 1 + " ");
					continue;
				}

				Console.Write(number - 1 + " ");
			}
		}
	}
}

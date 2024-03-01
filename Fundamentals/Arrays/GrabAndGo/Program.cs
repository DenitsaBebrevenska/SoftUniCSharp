namespace GrabAndGo
{
	internal class Program
	{
		static void Main()
		{
			long[] numbers = Console.ReadLine().
				Split().
				Select(long.Parse).
				ToArray();
			long number = long.Parse(Console.ReadLine());
			int lastIndex = -1;

			for (int i = numbers.Length - 1; i >= 0; i--)
			{
				if (numbers[i] == number)
				{
					lastIndex = i;
					break;
				}
			}

			if (lastIndex < 0)
			{
				Console.WriteLine("No occurrences were found!");
				return;
			}

			long sum = 0;

			for (int i = 0; i < lastIndex; i++)
			{
				sum += numbers[i];
			}

			Console.WriteLine(sum);
		}
	}
}
 
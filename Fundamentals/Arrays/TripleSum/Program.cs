namespace TripleSum
{
	internal class Program
	{
		static void Main()
		{
			int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
			bool matchFound = false;
			//2 7 5 0
			for (int i = 0; i < numbers.Length - 1; i++)
			{
				for (int j = i + 1; j < numbers.Length; j++)
				{
					int sum = numbers[i] + numbers[j];

					if (numbers.Contains(sum))
					{
						Console.WriteLine($"{numbers[i]} + {numbers[j]} == {sum}");
						matchFound = true;
					}
				}
			}

			if (!matchFound)
			{
				Console.WriteLine("No");
			}
		}
	}
}
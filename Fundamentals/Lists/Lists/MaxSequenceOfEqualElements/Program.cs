namespace MaxSequenceOfEqualElements
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();

			int maxCount = 1;
			int startingIndexLongest = 0;
			int count = 1;
			int startingIndex = 0;
			bool matchFound = false;

			for (int i = 0; i < numbers.Count - 1; i++)
			{
				if (numbers[i] == numbers[i + 1])
				{
					if (!matchFound)
					{
						matchFound = true;
						startingIndex = i;
					}
					count++;
				}
				else
				{
					matchFound = false;
					count = 1;
				}

				if (count > maxCount)
				{
					maxCount = count;
					startingIndexLongest = startingIndex;
				}
			}

			for (int i = startingIndexLongest; i < startingIndexLongest + maxCount; i++)
			{
				Console.Write(numbers[i] + " ");
			}
		}
	}
}

namespace LongestIncreasingSubsequence
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine()
				.Split()
				.Select(int.Parse).
				ToList();

			int[] length = new int[numbers.Count];
			int[] previous = new int[numbers.Count];

			for (int i = 0; i < numbers.Count; i++)
			{
				length[i] = 1;
				previous[i] = -1;
				for (int left = 0; left < i; left++)
				{
					if (numbers[i] > numbers[left] && length[i] <= length[left])
					{
						length[i] = length[left] + 1;
						previous[i] = left;
					}
				}
			}

			int maxLength = length.Max();
			int lastIndex = Array.IndexOf(length, maxLength);

			int[] reconstructedArray = new int[maxLength];
			int currentIndex = maxLength - 1;

			while (lastIndex >= 0)
			{
				reconstructedArray[currentIndex] = numbers[lastIndex];
				currentIndex--;
				lastIndex = previous[lastIndex];
			}

			string output = string.Join(" ",reconstructedArray);
			Console.WriteLine(output);
		}
	}
}

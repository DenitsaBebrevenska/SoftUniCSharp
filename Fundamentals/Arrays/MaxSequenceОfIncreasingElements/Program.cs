namespace MaxSequenceОfIncreasingElements
{
	internal class Program
	{
		static void Main()
		{
			int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
			string sequence = string.Empty;
			string longestSequence = string.Empty;
			int count = 0;
			int maxCount = 0;

			for (int i = 0; i < numbers.Length - 1; i++)
			{
				if (numbers[i] < numbers[i + 1])
				{
					count++;
					sequence += numbers[i] + " ";
					if (i == numbers.Length - 2 || numbers[i+1] >= numbers[i+2])
					{
						sequence += numbers[i + 1];
						count++;

						if (count > maxCount)
						{
							maxCount = count;
							longestSequence = sequence;
							sequence = string.Empty;
							count = 0;
						}
						else if (count == maxCount)
						{
							sequence = string.Empty;
							count = 0;
						}
					}
				}
			}

			Console.WriteLine(longestSequence);
		}
	}
}
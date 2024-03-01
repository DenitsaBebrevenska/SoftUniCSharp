namespace EqualSum
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			// 0  1  2  3
			// 1  2  3  3
			bool equalFound = false;
			for (int i = 0; i < numbers.Length; i++)
			{
				int sumLeft = 0, sumRight = 0;
				if (i == 0)
				{
					sumRight = CalculateRight(numbers, i);
				}
				else if (i == numbers.Length - 1)
				{
					sumLeft = CalculateLeft(numbers, i);
				}
				else
				{
					sumLeft = CalculateLeft(numbers, i);
					sumRight = CalculateRight(numbers, i);
				}
				if (sumLeft == sumRight)
				{
					equalFound = true;
                    Console.WriteLine(i);
                }
			}
			if (!equalFound)
			{
                Console.WriteLine("no");
            }
		}
		private static int CalculateLeft(int[] numbers, int index) 
		{
			int sumLeft = 0;
			
				for (int j = index - 1; j >= 0; j--)
				{
					sumLeft += numbers[j];
				}
			return sumLeft;
		}
		private static int CalculateRight(int[] numbers, int index)
		{
			int sumRight = 0;
			
				for (int k = index + 1; k <= numbers.Length - 1; k++)
				{
					sumRight += numbers[k];
				}
			return sumRight;
		}
	}
}
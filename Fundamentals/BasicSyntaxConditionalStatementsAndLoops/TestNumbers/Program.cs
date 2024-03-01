namespace TestNumbers
{
	internal class Program
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());
			int m = int.Parse(Console.ReadLine());
			int maxSum = int.Parse(Console.ReadLine());
			int sum = 0;
			int counter = 0;
			bool maxSumReached = false;
			for (int i = n; i >= 1; i--)
			{
				for (int j = 1; j <= m; j++)
				{
					sum += (3 * (i * j));
					counter++;

					if (sum >= maxSum)
					{
						maxSumReached = true;
						break;
					}

				}
				if (maxSumReached)
				{
					break;
				}
			}
			
			Console.WriteLine($"{counter} combinations");
			Console.WriteLine(maxSumReached ? $"Sum: {sum} >= {maxSum}" : $"Sum: {sum}");
		}
	}
}
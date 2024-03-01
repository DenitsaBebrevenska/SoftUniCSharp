namespace PrimesInGivenRange
{
	internal class Program
	{
		static void Main()
		{
			int start = int.Parse(Console.ReadLine());
			int end = int.Parse(Console.ReadLine());
			PrintPrimeNumbers(start, end);
		}

		static List<int> FindPrimesInRange(int start, int end)
		{
			List<int> primeNumbers = new List<int>();
			for (int i = start; i <= end; i++)
			{
				int count = 0;
				if (i <= 1)
				{
					continue;
				}

				for (int j = 2; j <= Math.Sqrt(i); j++)
				{
					if (i % j == 0)
					{
						count = 1;
						break;
					}
				}

				if (count == 0)
				{
					primeNumbers.Add(i);
				}
			}
			return primeNumbers;
		}

		static void PrintPrimeNumbers(int start, int end)
		{
			Console.WriteLine(string.Join(", ", FindPrimesInRange(start, end)));
		}
	}
}

namespace Numbers
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();
			double averageNumber = FindAverageValue(numbers);
			List<int> result = GetNumbersHigherThanAverage(numbers, averageNumber);
			result.Sort();
			result.Reverse();
			PrintNumbers(result);
		}

		static double FindAverageValue(List<int> numbers)
		{
			double result = 0;
			foreach (int number in numbers)
			{
				result += number;
			}	
			return result /= numbers.Count;
		}

		static List<int> GetNumbersHigherThanAverage(List<int> numbers, double averageNum)
		{
			List<int> result = new();
			foreach (int number in numbers)
			{
				if (number > averageNum)
				{
					result.Add(number);
				}
			}
			return result;
		}

		static void PrintNumbers(List<int> result)
		{
			if (result.Count == 0)
			{
				Console.WriteLine("No");
			}
			else if (result.Count > 5)
			{
				for (int i = 0; i < 5; i++)
				{
					Console.Write(result[i] + " ");
				}
			}
			else
			{
				Console.WriteLine(string.Join(' ', result));
			}
		}
	}
}
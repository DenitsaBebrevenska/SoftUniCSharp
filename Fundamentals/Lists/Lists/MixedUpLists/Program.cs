namespace MixedUpLists
{
	internal class Program
	{
		static void Main()
		{
			List<int> list1 = ReadInput();
			List<int> list2 = ReadInput();

			int rangeElement1;
			int rangeElement2;
			if (!isFistSmaller(list1, list2))
			{
				rangeElement1 = list1[^2];
				rangeElement2 = list1[^1];
				list1.RemoveRange(list1.Count - 2, 2);
			}
			else
			{
				rangeElement1 = list2[0];
				rangeElement2 = list2[1];
				list2.RemoveRange(0, 2);
			}

			int[] mixedNumbers = CreateMixedArray(list1, list2);
			
			int maxInt = Math.Max(rangeElement1, rangeElement2);
			int minInt = Math.Min(rangeElement1, rangeElement2);
			List<int> result = GetNumbersInRange(maxInt, minInt, mixedNumbers);
			result.Sort();
			Console.WriteLine(string.Join(' ', result));
		}
		static List<int> ReadInput()
		{
			return Console.ReadLine().Split().Select(int.Parse).ToList();
		}
		static bool isFistSmaller(List<int> list1, List<int> list2)
		{
			return list1.Count < list2.Count;
		}
		static int[] CreateMixedArray(List<int> list1, List<int> list2)
		{
			int[] mixedNumbers = new int[list1.Count * 2];
			int j = 0;
			for (int i = 0; i < list1.Count; i++)
			{
				mixedNumbers[j] = list1[i];
				j += 2;
			}
			j = 1;
			for (int i = list2.Count - 1; i >= 0; i--)
			{
				mixedNumbers[j] = list2[i];
				j += 2;
			}
			return mixedNumbers;
		}
		static List<int> GetNumbersInRange(int maxInt, int minInt, int[] mixedNumbers)
		{
			List<int> result = new List<int>();
			foreach (int number in mixedNumbers)
			{
				if (number < maxInt && number > minInt)
				{
					result.Add(number);
				}
			}
			return result;
		}
	}
}
namespace MergingLists
{
	internal class Program
	{
		static void Main()
		{
			List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
			List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
			List<int> combinedList = new List<int>();

			if (firstList.Count == secondList.Count)
			{
				combinedList = MergeLists(firstList, secondList, firstList.Count);
			}
			else
			{
				int count = 0;
				if (firstList.Count > secondList.Count)
				{
					count = secondList.Count;
				}
				else
				{
					count = firstList.Count;
				}

				combinedList = MergeLists(firstList, secondList, count);
				combinedList.AddRange(GetRemainingElements(firstList, secondList));
			}

			Console.WriteLine(string.Join(' ', combinedList));
		}

		static List<int> MergeLists(List<int>firstList, List<int> secondList, int count)
		{
			List<int> combinedList = new List<int>();
			for (int i = 0; i < count; i++)
			{
				combinedList.Add(firstList[0]);
				firstList.RemoveAt(0);	
				combinedList.Add(secondList[0]);
				secondList.RemoveAt(0);
			}
			return combinedList;
		}

		static List<int> GetRemainingElements(List<int> firstList, List<int> secondList)
		{
			List<int> remainingInts = new List<int>();
			if (firstList.Count > 0) //if anything remained in that list
			{
				for (int i = 0; i < firstList.Count; i++)
				{
					remainingInts.Add(firstList[i]);
				}
			}
			else if (secondList.Count > 0) 
			{
				for (int i = 0; i < secondList.Count; i++)
				{
					remainingInts.Add(secondList[i]);
				}
			}
			return remainingInts;
		}
	}
}
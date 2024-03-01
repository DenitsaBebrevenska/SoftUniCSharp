namespace BombNumbers
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();

			string[] bomb = Console.ReadLine().
				Split();
			int bombNumber = int.Parse(bomb[0]);
			int bombPower = int.Parse(bomb[1]);

			int indexStartRemoving = 0;
			int countToRemove = 0;
			for (int i = 0; i < numbers.Count; i++)
			{
				if (numbers[i] == bombNumber)
				{
					indexStartRemoving = GetStartIndex(i, bombPower);
					countToRemove = GetCount(numbers, bombPower,indexStartRemoving);
					numbers.RemoveRange(indexStartRemoving, countToRemove);
					i = 0; //return to the begining of the list
				}
			}
			Console.WriteLine(numbers.Sum());
		}
		static int GetStartIndex(int i, int bombPower)
		{
			int indexStartRemoving = i - bombPower >= 0 ? i - bombPower : 0;

			return indexStartRemoving;
		}
		static int GetCount(List<int> numbers, int bombPower, int indexStartRemoving)
		{
			int countToRemove = bombPower * 2 + 1;
            if (indexStartRemoving + countToRemove > numbers.Count)
            {
                countToRemove = numbers.Count - indexStartRemoving;
            }
			return countToRemove;
		}
	}
}
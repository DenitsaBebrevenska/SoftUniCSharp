namespace TakeSkipRope
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			List<int> numbers = new List<int>();
			List<char> characters = new List<char>();
			DivideDigitsFromChars(input, numbers, characters);

			List<int> takeList = new List<int>();
			List<int> skipList = new List<int>();
			PopulateTakeAndSkipLists(numbers, takeList, skipList);

			string message = CreateMessage(takeList, skipList, characters);
			Console.WriteLine(message);
		}
		static string CreateMessage(List<int> takeList, List<int> skipList, List<char> characters)
		{
			string result = "";
			int index = 0;
			for (int i = 0; i < takeList.Count; i++)
			{
				int take = takeList[i];
				int skip = skipList[i];

				if (index + take > characters.Count)
				{
					take = characters.Count - index;
				}

				for (int j = 0; j < take; j++)
				{
					result += characters[index + j];
				}

				index += take + skip;
			}
			return result;
		}
		static void PopulateTakeAndSkipLists(List<int> numbers, List<int> takeList, List<int> skipList)
		{
			for (int i = 0; i < numbers.Count; i++)
			{
				if (i % 2 == 0)
				{
					takeList.Add(numbers[i]);
				}
				else
				{
					skipList.Add(numbers[i]);
				}
			}
		}
		static void DivideDigitsFromChars(string input, List<int> numbers, List<char> characters)
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] >= 48 && input[i] <= 57) //is a digit
				{
					numbers.Add(int.Parse(input[i].ToString()));
				}
				else //is a char
				{
					characters.Add(input[i]);
				}
			}
		}
	}
}
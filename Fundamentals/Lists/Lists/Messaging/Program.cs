namespace Messaging
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();
			List<char> text = Console.ReadLine().ToList();
			
			List<char> messageChars = new();
			for (int i = 0; i < numbers.Count; i++)
			{
				int currentIndex = GetIndex(numbers[i], text.Count);
				messageChars.Add(text[currentIndex]);
				text.RemoveAt(currentIndex);
			}
            Console.WriteLine(string.Join("",messageChars));
        }
		static int CalculateSum(int currentNumber)
		{
			int sum = 0;
			while (currentNumber > 0)
			{
				int lastDigit = currentNumber % 10;
				sum += lastDigit;
				currentNumber /= 10;
			}
			return sum;
		}
		static int GetIndex(int currentNumber, int count)
		{
			int index = CalculateSum(currentNumber);

			if (index > count)
			{
				if (index % count == 0)
				{
					index = count - 1;
				}
				else
				{
					index %=  count;
				}
			}
			return index;
		}
	}
}
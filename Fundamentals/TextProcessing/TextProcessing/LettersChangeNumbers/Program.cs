namespace LettersChangeNumbers
{
	internal class Program
	{
		static void Main()
		{
			string[] strings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

			double sum = 0;
			for (int i = 0; i < strings.Length; i++)
			{
				string currentString = strings[i];
				char firstLetter = currentString[0];
				char secondLetter = currentString[^1];
				double number = double.Parse(currentString.Substring(1, currentString.Length - 2));
				double currentSum = 0;

				if (IsUpperCase(firstLetter))
				{
					currentSum += number / GetPositionInAlphabet(firstLetter);
				}
				else
				{
					currentSum += number * GetPositionInAlphabet(firstLetter);
				}

				if (IsUpperCase(secondLetter))
				{
					currentSum -= GetPositionInAlphabet(secondLetter);
				}
				else
				{
					currentSum += GetPositionInAlphabet(secondLetter);
				}

				sum += currentSum;
			}

			Console.WriteLine($"{sum:F2}");
		}

		static bool IsUpperCase(char letter)
		{
			return letter >= 65 && letter <= 90;
		}

		static int GetPositionInAlphabet(char letter)
		{
			return (int)letter % 32;
		}

	}
}
namespace MasterNumber
{
	internal class Program
	{
		static void Main()
		{
			int number = int.Parse(Console.ReadLine());
			for (int i = 1; i <= number; i++)
			{
				if (IsPalindrome(i) && IsSumDivisibleBySeven(i) && HasOneEvenDigit(i))
				{
					Console.WriteLine(i);
				}
			}
		}

		static bool IsPalindrome(int number)
		{
			string numberAsString = number.ToString();
			int length = numberAsString.Length;

			for (int i = 0; i < length / 2; i++)
			{
				if (numberAsString[i] != numberAsString[length - i - 1])
				{
					return false;
				}
			}

			return true;
		}

		static bool IsSumDivisibleBySeven(int number)
		{
			string numberAsString = number.ToString();
			int[] numbers = numberAsString.ToCharArray().Select(x => x - '0').ToArray();
			return numbers.Sum(x => x) % 7 == 0;
		}

		static bool HasOneEvenDigit(int number)
		{
			string numberAsString = number.ToString();
			for (int i = 0; i < numberAsString.Length; i++)
			{
				int currentInt = numberAsString[i] - '0';
				if (currentInt % 2 == 0)
				{
					return true;
				}
			}
			return false;
		}

	}
}

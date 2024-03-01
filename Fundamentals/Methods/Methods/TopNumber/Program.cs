namespace TopNumber
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int endValue = int.Parse(Console.ReadLine());
			PrintTopNumbers(endValue);
		}
		static void PrintTopNumbers(int endValue)
		{
			for (int i = 1; i <= endValue; i++)
			{
				if (CheckDivision(i) && CheckOddDigit(i))
				{
					Console.WriteLine(i);
				}
			}
		}

		static bool CheckDivision(int number)
		{
			number = CalculateSumAllDigits(number);
			if (number % 8 == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		static bool CheckOddDigit(int number)
		{
			int counterOdd = 0;
			while (number > 0)
			{
				int lastDigit = number % 10;
				if (lastDigit % 2 != 0)
				{
					counterOdd++;
				}

				number /= 10;
			}

			if (counterOdd > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		static int CalculateSumAllDigits(int number)
		{
			int sum = 0;
			while (number > 0)
			{
				int lastDigit = number % 10;
				sum += lastDigit;
				number /= 10;
			}

			return sum;
		}
	}
}
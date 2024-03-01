namespace MultiplyEvensByOdds
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int number = Math.Abs(int.Parse(Console.ReadLine()));
            Console.WriteLine(GetMultipleOfEvenAndOdds(number));
        }
		static int GetSumOfEvenDigits(int number)
		{
			int sum = 0;
			while (number > 0) 
			{
				int lastDigit = number % 10;
				if (lastDigit % 2 == 0)
				{
					sum += lastDigit;
				}
				number /= 10;
			}
			return sum;
		}
		static int GetSumOfOddDigits(int number)
		{
			int sum = 0;
			while (number > 0)
			{
				int lastDigit = number % 10;
				if (lastDigit % 2 != 0)
				{
					sum += lastDigit;
				}
				number /= 10;
			}
			return sum;
		}
		static int GetMultipleOfEvenAndOdds(int number)
		{
			int sumOdd = GetSumOfOddDigits(number);
			int sumEven = GetSumOfEvenDigits(number);
			return sumOdd * sumEven;
		}
	}
}
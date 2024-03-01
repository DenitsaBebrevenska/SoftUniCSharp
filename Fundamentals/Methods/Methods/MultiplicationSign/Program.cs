using System.Net.Http.Headers;

namespace MultiplicationSign
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//find if the product of three numbers is either zero, positive or negative without multiplying them
			int num1 = int.Parse(Console.ReadLine());
			int num2 = int.Parse(Console.ReadLine());
			int num3 = int.Parse(Console.ReadLine());
			string result = FindResult(CheckForZero(num1, num2, num3), CheckForNegativeResult(num1, num2, num3));
            Console.WriteLine(result);
        }
		static bool CheckForNegativeResult(int num1, int num2, int num3)
		{   
			int counter = 0;
			int[] numbers = { num1, num2, num3 };
			for (int i = 0; i < numbers.Length; i++)
			{
				if (numbers[i] < 0)
				{
					counter++;
				}
			}
			// the result will be negative if 1 or 3 numbers are negative, the result will be positive if 0 or 2 numbers are negative
			if (counter == 1 || counter == 3)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		static bool CheckForZero(int num1, int num2, int num3)
		{
			if (num1 == 0 || num2 == 0 || num3 == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		static string FindResult(bool hasZero, bool hasNegativeNumbers)
		{
			if (hasZero)
			{
				return "zero";
			}
			else if (hasNegativeNumbers)
			{
				return "negative";
			}
			else
			{
				return "positive";
			}
		}
	}
}
using System.Numerics;

namespace FactorialTrailingZeroes
{
	internal class Program
	{
		static void Main()
		{
			Console.WriteLine(CalculateTrailingZeroes());
		}

		static BigInteger GetFactorial(int number)
		{
			BigInteger factorial = 1;
			for (int i = 1; i <= number; i++)
			{
				factorial *= i;
			}
			return factorial;
		}

		static uint CalculateTrailingZeroes()
		{
			BigInteger number = GetFactorial(int.Parse(Console.ReadLine()));
			string numberAsString = number.ToString();
			uint counter = 0;

			for (int i = numberAsString.Length - 1; i >= 0; i--)
			{
				if (numberAsString[i] == '0')
				{
					counter++;
				}
				else
				{
					break;
				}
			}

			return counter;
		}
	}
}

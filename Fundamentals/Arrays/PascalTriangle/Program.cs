using System.Numerics;

namespace PascalTriangle
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//formula
			//C(n, k) = n! / (k! * (n - k)!) 
			// n is row number, k is the index inside the array in our case
			//for each roll -  starting from k = 0 and ending at the row number n+1.
			//a factorial of 60 has too many numbers, have to use BigInteger
			long rows = long.Parse(Console.ReadLine());
			long counter = 1;
			

			while (counter <= rows)
			{
				BigInteger[] currentRow = new BigInteger[counter];
				for (long n = 0; n < currentRow.Length; n++)
				{
					for (long k = 0; k < currentRow.Length; k++)
					{
						currentRow[k] = BinomialCoefficient(n, k);
					}
				}
				string arrayToString = string.Join(" ", currentRow);
				Console.WriteLine(arrayToString);
				counter++;
			}

		}

		static BigInteger BinomialCoefficient(long n, long k)
		{
			BigInteger factorialN = GetFactorial(n);
			BigInteger factorialK = GetFactorial(k);
			BigInteger factorialBoth = GetFactorial(n - k);
			BigInteger number = factorialN / (factorialK * factorialBoth);
			return number;
		}

		static BigInteger GetFactorial(long number)
		{
			BigInteger factorial = 1;
			for (long i = 1; i <= number; i++)
			{
				factorial *= i;
			}
			return factorial;
		}
	}
}
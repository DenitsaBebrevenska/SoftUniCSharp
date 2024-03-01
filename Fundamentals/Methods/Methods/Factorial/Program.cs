using System.Numerics;

namespace Factorial
{
	internal class Program
	{
		static void Main()
		{
			Console.WriteLine(GetFactorial(int.Parse(Console.ReadLine())));
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
	}
}

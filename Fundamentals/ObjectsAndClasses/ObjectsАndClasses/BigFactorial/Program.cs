using System.Numerics;

namespace BigFactorial
{
	internal class Program
	{
		static void Main()
		{
			int number = int.Parse(Console.ReadLine());
			BigInteger factorial = CalculateFactorial(number);
			Console.WriteLine(factorial);
		}

		static BigInteger CalculateFactorial(int number)
		{
			BigInteger factorial = 1;
			for (int i = number; i > 1; i--)
			{
				factorial *= i;
			}
			return factorial;
		}
	}
}
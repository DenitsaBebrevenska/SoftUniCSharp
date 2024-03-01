using System.Numerics;

namespace ConvertFromBase10ToBaseN
{
	internal class Program
	{
		static void Main()
		{
			//Do not use any built in converting functionality, try to write your own algorithm.
			BigInteger[] numbers = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
			BigInteger nBase = numbers[0];
			BigInteger numberBase10 = numbers[1];
			string remainders = string.Empty;

			while (numberBase10 > 0)
			{
				BigInteger remainder = numberBase10 % nBase;
				numberBase10 /= nBase;
				remainders += remainder;
			}

			remainders = new string(remainders.ToCharArray().Reverse().ToArray());

			Console.WriteLine(remainders);
		}
	}
}

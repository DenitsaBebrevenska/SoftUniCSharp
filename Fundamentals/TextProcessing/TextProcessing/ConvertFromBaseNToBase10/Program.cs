using System.Numerics;

namespace ConvertFromBaseNToBase10
{
	internal class Program
	{
		static void Main()
		{
			//Do not use any built in converting functionality, try to write your own algorithm.
			string[] numbers = Console.ReadLine().Split();
			ulong nBase = ulong.Parse(numbers[0]);
			string numberToConvert = numbers[1];
			BigInteger sum = 0;
			int power = numberToConvert.Length -1;

			for (int i = 0; i < numberToConvert.Length; i++)
			{
				int currentNumber = numberToConvert[i] - '0';
				sum += currentNumber * GetNumberRaisedToPower(nBase,power);
				power--;
			}

			Console.WriteLine(sum);
		}

		static BigInteger GetNumberRaisedToPower(ulong number, int power)
		{
			BigInteger result = 1;
			for (int i = 0; i < power; i++)
			{
				result *= number;
			}
			return result;
		}
	}
}
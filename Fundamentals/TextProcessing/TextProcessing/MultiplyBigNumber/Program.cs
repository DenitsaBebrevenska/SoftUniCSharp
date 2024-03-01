using System.Text;

namespace MultiplyBigNumber
{
	internal class Program
	{
		static void Main()
		{
			//BigInteger is not supposed to be used in this assignment

			string bigNumber = Console.ReadLine().TrimStart('0');
			int singleDigit = int.Parse(Console.ReadLine());

			if (singleDigit == 0) //avoiding making a string full of 0s
			{
				Console.WriteLine("0");
				return;
			}
			StringBuilder sb = new StringBuilder();

			int leftOver = 0;
			for (int i = bigNumber.Length - 1; i >= 0; i--)
			{
				int currentNumber = bigNumber[i] - '0';
				int result = currentNumber * singleDigit + leftOver;
				int numberToAppend = result % 10;
				sb.Append(numberToAppend);
				leftOver = result / 10;
			}

			if (leftOver != 0)
			{
				sb.Append(leftOver);
			}

			string reversedString = new string(sb.ToString().Reverse().ToArray());

			Console.WriteLine(reversedString);
		}
	}
}
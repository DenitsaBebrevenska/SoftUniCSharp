using System.Text;

namespace SumBigNumbers
{
	internal class Program
	{
		static void Main()
		{
			string number1 = Console.ReadLine();
			string number2 = Console.ReadLine();

			if (number1.All(x => x == '0') && number2.All(x => x == '0')) 
			{
				Console.WriteLine(0);
				return;
			}

			if (number1.Length != number2.Length)
			{
				int lengthDifference = Math.Abs(number1.Length - number2.Length);
				string leadingZeroes = new string('0', lengthDifference);

				if (number1.Length > number2.Length)
				{
					number2 = leadingZeroes + number2;
				}
				else
				{
					number1 = leadingZeroes + number1;
				}
			}

			Console.WriteLine(GetSum(number1, number2));
		}

		static string GetSum(string number1, string number2)
		{
			StringBuilder sumBuilder = new StringBuilder();
			int remainder = 0;

			for (int i = number1.Length - 1; i >= 0; i--)
			{
				int digit1 = number1[i] - '0';
				int digit2 = number2[i] - '0';
				int sumDigits = digit1 + digit2 + remainder;

				if (sumDigits < 10)
				{
					sumBuilder.Append(sumDigits);
					remainder = 0;
				}
				else
				{
					sumBuilder.Append(sumDigits % 10);
					remainder = 1;
				}
			}

			sumBuilder.Append(remainder);

			return new string(sumBuilder.ToString().ToCharArray().Reverse().ToArray()).TrimStart('0');
		}
	}
}

using System.ComponentModel;

namespace FromLeftToTheRight
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			for (int i = 1; i <= n; i++)
			{
				string input = Console.ReadLine();
				int indexSpace = input.IndexOf(' ');
				string num1String = string.Empty, num2String = string.Empty;
				for (int j = 0; j < indexSpace; j++)
				{
					num1String += input[j];
				}
				for (int k = indexSpace + 1; k < input.Length; k++)
				{
					num2String += input[k];
				}
				long num1Long = Convert.ToInt64(num1String);
				long num2Long = Convert.ToInt64(num2String);

				if (num1Long > num2Long)
				{
					Console.WriteLine(CalculateSum(num1Long));
                }
				else
				{
                    Console.WriteLine(CalculateSum(num2Long));
                }
			
			}

		}
		private static long CalculateSum(long number)
		{
			long sum = 0;
			long currentNum = Math.Abs(number);

			while (currentNum > 0)
			{
				long lastDigit = currentNum % 10;
				sum += lastDigit;
				currentNum /= 10;
			}
			return sum;
		}

	}
}
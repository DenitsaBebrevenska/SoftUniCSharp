using System.ComponentModel.DataAnnotations;

namespace SumDigits
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//string inputInt = Console.ReadLine();
			//int sum = 0;
			//for (int i = 0; i < inputInt.Length ; i++)
			//{
			//	char current = inputInt[i];
			//	int currentNum = (int) (current - '0');
			//	sum += currentNum;
			//}
			//         Console.WriteLine(sum);


			int inputInt = int.Parse(Console.ReadLine());
			int sum = 0;
			while (inputInt > 0)
			{
				int lastDigit = inputInt % 10;
				sum += lastDigit;
				inputInt /= 10;
				
			}
            Console.WriteLine(sum);
        }
	}
}
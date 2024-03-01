namespace Calculations
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string operation = Console.ReadLine();
			int number1 = int.Parse(Console.ReadLine());
			int number2 = int.Parse(Console.ReadLine());
			Calculate(operation, number1, number2);
		}
		static void Calculate(string operations, int number1, int number2)
		{
			if (operations == "add")
			{
				Console.WriteLine(number1 + number2);
			}
			else if (operations == "multiply")
			{
				Console.WriteLine(number1 * number2);
			}
			else if (operations == "substract")
			{
				Console.WriteLine(number1 - number2);
			}
			else if (operations == "divide")
			{
                Console.WriteLine(number1 / number2);
            }
		}
	}
}
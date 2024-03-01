namespace MathOperations
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int number1 = int.Parse(Console.ReadLine());
			string operate = Console.ReadLine();
			int number2 = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculate(number1, operate, number2));
        }
		static int Calculate(int number1, string operate, int number2)
		{
			if (operate == "+")
			{
				return number1 + number2;
			}
			else if (operate == "-")
			{
				return number1 - number2;
			}
			else if (operate == "*") 
			{
				return number1 * number2;
			}
			else 
			{
				return number1 / number2;
			}
		}
	}
}
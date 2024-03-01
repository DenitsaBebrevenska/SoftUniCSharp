namespace AddAndSubtract
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int number1 = int.Parse(Console.ReadLine());
			int number2 = int.Parse(Console.ReadLine());
			int number3 = int.Parse(Console.ReadLine());
			
			CalculateAndPrintResult(number1, number2, number3);
		}

		static int CalculateSum(int number1, int number2)
		{
			return number1 + number2;
		}

		static void CalculateAndPrintResult(int number1, int number2, int number3)
		{
			int sum = CalculateSum(number1, number2);
			int result = sum - number3;
			Console.WriteLine(result);
		}
	}
}
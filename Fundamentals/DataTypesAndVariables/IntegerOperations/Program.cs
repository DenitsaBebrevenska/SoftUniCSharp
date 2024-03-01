namespace IntegerOperations
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int firstNum = int.Parse(Console.ReadLine());
			int secondNum = int.Parse(Console.ReadLine());
			int thirdNum = int.Parse(Console.ReadLine());
			int fourthNum = int.Parse(Console.ReadLine());

			int sum = firstNum + secondNum;
			int division = sum / thirdNum;
			int multiply = division * fourthNum;

            Console.WriteLine(multiply);
        }
	}
}
namespace ExactSumOfRealNumbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); //numbers that will be added to sum
			decimal sum = 0;

			for (int i = 1; i <= n; i++)
			{
				decimal currentNumber = decimal.Parse(Console.ReadLine());
				sum += currentNumber;
			}

			Console.WriteLine(sum);

		}
	}
}
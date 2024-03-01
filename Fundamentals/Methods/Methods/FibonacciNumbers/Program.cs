namespace FibonacciNumbers
{
	internal class Program
	{
		static void Main()
		{
			Console.WriteLine(GetFibonacci(int.Parse(Console.ReadLine())));
		}

		static long GetFibonacci(int n)
		{
			if (n <= 1)
			{
				return 1;
			}

			long fib1 = 1;
			long fib2 = 1;

			for (int i = 2; i <= n; i++)
			{
				long temp = fib1;
				fib1 += fib2;
				fib2 = temp;
			}

			return fib1;
		}
	}
}

namespace PrimeChecker
{
	internal class Program
	{
		static void Main()
		{
			Console.WriteLine(IsPrime(long.Parse(Console.ReadLine())));
		}

		static bool IsPrime(long n)
		{
			if (n <= 1)
			{
				return false;
			}

			for (long i = 2; i <= (long)Math.Sqrt(n); i++)
			{
				if ((n % i) == 0)
				{
					return false;
				}
			}
			return true;
		}
		
	}
}

namespace SieveOfEratosthenes
{
	internal class Program
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());
			bool[] primes = new bool[n + 1];

			for (int i = 0; i <= n; i++)
			{
				primes[i] = true;
			}

			primes[0] = primes[1] = false;

			for (int i = 0; i <= n; i++)
			{
				if (!primes[i])
				{
					continue;
				}

				Console.Write(i + " ");

				for (int p = 2 * i; p <= n; p += i)
				{
					primes[p] = false;
				}
			}
		}
	}
}
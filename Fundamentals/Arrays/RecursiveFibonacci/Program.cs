using System.Diagnostics;

namespace RecursiveFibonacci
{
	internal class Program
	{
		//I barely understood Memoization!
		//dictionary to store the calculated values
		static Dictionary<int, long> cache = new Dictionary<int, long>();
		static void Main()
		{
			//GetFibonacci(n) = GetFibonacci(n-1) + GetFibonacci(n-2)
			//GetFibonacci(2) should return 1 and GetFibonacci(1) should return 1.
			// n > 0 and <= 50
			// 12586269025 is the 50th fib.number so we need long as data type
			int n = int.Parse(Console.ReadLine());
			long result = GetFibonacci(n);

			Console.WriteLine(result);
		}

		static long GetFibonacci(int n)
		{
			if(cache.ContainsKey(n)) //if we have this result stored, just return that to the main method
			{
				return cache[n];
			}

			long result; 
			if (n <= 1) //0 and 1 return just 0 and 1
			{
				result = n;
			}
			else // calculate and store
			{
				result = GetFibonacci(n - 1) + GetFibonacci(n - 2);
				cache[n] = result;
			}
			return result;
		}
	}
}
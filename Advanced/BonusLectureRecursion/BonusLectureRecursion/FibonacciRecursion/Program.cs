namespace FibonacciRecursion
{
    internal class Program
    {
        static Dictionary<int, long> memoResults = new(); //memoization
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacciNumber(n,memoResults));
        }

        private static long GetFibonacciNumber(int n, Dictionary<int, long> memoResults)
        {
            if (n <= 1)
            {
                return n;
            }

            if (memoResults.TryGetValue(n, out long result))
            {
                return result;
            }

            result = GetFibonacciNumber(n - 1, memoResults) + GetFibonacciNumber(n - 2, memoResults);
            memoResults[n] = result;
            return result;
        }
    }
}

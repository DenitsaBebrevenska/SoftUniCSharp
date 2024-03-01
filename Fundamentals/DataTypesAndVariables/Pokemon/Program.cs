namespace Pokemon
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); //power
			int m = int.Parse(Console.ReadLine()); //distance
			int y = int.Parse(Console.ReadLine()); //exhaustion
			int targets = 0, originalValueN = n;
			while (n >= m)
			{
				n -= m;
				targets++;
				double nAsDouble = (double)n;
				if ( nAsDouble == originalValueN * 0.5)
				{
					if (y > 0)
					{
						n /= y;
					}
				}
			}
            Console.WriteLine(n);
            Console.WriteLine(targets);
        }
	}
}
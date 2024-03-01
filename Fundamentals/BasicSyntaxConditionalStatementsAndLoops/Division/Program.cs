namespace Division
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int number = int.Parse(Console.ReadLine());
			int divisor = 0;
			bool hasDivisor = true;
			if (number % 10 == 0)
			{
				divisor = 10;
            }
			else if (number % 7 == 0)
			{
				divisor = 7;
            }
			else if (number % 6 == 0)
			{
				divisor = 6;
			}
			else if (number % 3 == 0)
			{
				divisor = 3;
			}
			else if (number % 2 == 0)
			{
				divisor = 2;
			}
			else
			{
                Console.WriteLine("Not divisible");
				hasDivisor = false;
            }
			if (hasDivisor) 
			{
                Console.WriteLine($"The number is divisible by {divisor}");
            }
		}
	}
}
namespace SumOfOddNumbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); // n-number of times the loop will go
			int sum = 0;
			int counter = 0;
			

			for (int i = 1; i < int.MaxValue; i += 2)
			{
                Console.WriteLine(i);
				sum += i;
				counter++;
				if (counter == n)
				{
					break;
				}
            }
            Console.WriteLine("Sum: " + sum);
        }
	}
}
namespace EvenAndOddSubtraction
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			int sumEven = 0, sumOdd = 0;	
			foreach (int i in input) 
			{
				if (i % 2 == 0)
				{
					sumEven += i;
				}
				else
				{
					sumOdd += i;
				}
			}
            Console.WriteLine(sumEven-sumOdd);
        }
	}
}
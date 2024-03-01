namespace StrongNumber
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int number = int.Parse(Console.ReadLine());
			int numberToCheck = number;
			int sum = 0;
			
			while (numberToCheck > 0)
			{
				int currentSum = 1;
				int currentNum = numberToCheck % 10;
				for (int i = 1; i <= currentNum; i++) 
				{
					currentSum *= i;
				}
				numberToCheck /= 10;
				sum += currentSum;
			}
			if (sum == number)
			{
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
	}
}
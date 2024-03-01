namespace SpecialNumbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); //times the for loop will go
			
			for (int i = 1; i <= n; i++)
			{
				int sum = 0;
				int currentNum = i;
				while (true)
				{
					int lastDigit = currentNum % 10;
					sum += lastDigit;
					currentNum /= 10;
					if (currentNum <= 0)
					{
						break;
					}
				}
				if (sum == 5 || sum == 7 || sum == 11)
				{
					Console.WriteLine($"{i} -> True");
				}
				else
				{
					Console.WriteLine($"{i} -> False");
				}
            }
		}
	}
}
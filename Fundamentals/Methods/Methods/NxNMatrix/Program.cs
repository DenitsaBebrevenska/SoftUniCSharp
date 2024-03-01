namespace NxNMatrix
{
	internal class Program
	{
		static void Main()
		{
			int number = int.Parse(Console.ReadLine());
			PrintNTimesN(number);
		}

		static void PrintNTimesN(int number)
		{
			for (int j = 1; j <= number; j++)
			{
				for (int i = 1; i <= number; i++)
				{
					Console.Write(number + " ");
				}

				Console.WriteLine();
			}
			
		}
	}
}
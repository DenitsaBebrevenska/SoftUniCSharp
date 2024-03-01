namespace DrawAFilledSquare
{
	internal class Program
	{
		static void Main()
		{
			int number = int.Parse(Console.ReadLine());
			PrintHeaderOrFooter(number);
			PrintBody(number);
			PrintHeaderOrFooter(number);
		}

		static void PrintHeaderOrFooter(int n)
		{
			Console.WriteLine(new string('-', n * 2));
		}

		static void PrintBody(int n)
		{
			for (int j = 0; j < n - 2; j++)
			{
				Console.Write('-');
				for (int i = 1; i < n; i++)
				{
					Console.Write(@"\/");
				}

				Console.WriteLine('-');
			}
			
		}
	}
}
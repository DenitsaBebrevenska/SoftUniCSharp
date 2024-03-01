namespace PrintingTriangle
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int input = int.Parse(Console.ReadLine());
			PrintTriangle(input);
		}
		static void PrintLine(int start, int end)
		{
			for (int i = start; i <= end; i++)
			{
				Console.Write(i + " ");
            }
		}
		static void PrintTriangle(int number)
		{
			for (int i = 1; i <= number; i++)
			{
				PrintLine(1, i);
				Console.WriteLine();
			}
			for (int i = number - 1; i >= 1; i--)
			{
				PrintLine(1, i);
				Console.WriteLine();
			}
		}
	}
}
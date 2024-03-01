namespace SumOfChars
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); //n -number of lines that will follow
			int sum = 0;
			for (int i = 1; i <= n; i++)
			{
				string currentChar = Console.ReadLine();
				int currentNum = currentChar[0];
				sum += currentNum;
			}
            Console.WriteLine($"The sum equals: {sum}");
        }
	}
}
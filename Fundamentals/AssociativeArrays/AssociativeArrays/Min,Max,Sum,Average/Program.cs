namespace Min_Max_Sum_Average
{
	internal class Program
	{
		static void Main()
		{
			int numberOfRows = int.Parse(Console.ReadLine());
			List<int> numbers = new List<int>();

			for (int i = 0; i < numberOfRows; i++)
			{
				numbers.Add(int.Parse(Console.ReadLine()));
			}

			Console.WriteLine($"Sum = {numbers.Sum()}");
			Console.WriteLine($"Min = {numbers.Min()}");
			Console.WriteLine($"Max = {numbers.Max()}");
			Console.WriteLine($"Average = {numbers.Average()}");
		}
	}
}

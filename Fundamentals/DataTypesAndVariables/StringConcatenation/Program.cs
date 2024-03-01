namespace StringConcatenation
{
	internal class Program
	{
		static void Main()
		{
			char delimiter = Console.ReadLine()[0];
			string type = Console.ReadLine();
			sbyte lines = sbyte.Parse(Console.ReadLine());
			string evenLines = string.Empty;
			string oddLines = string.Empty;

			for (int i = 1; i <= lines; i++)
			{
				if (i % 2 == 0)
				{
					evenLines += Console.ReadLine() + delimiter;

				}
				else
				{
					oddLines += Console.ReadLine() + delimiter;
				}
			}
			Console.WriteLine(type == "odd" ? oddLines.Remove(oddLines.Length - 1) : evenLines.Remove(evenLines.Length - 1));

		}
	}
}
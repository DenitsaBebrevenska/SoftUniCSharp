namespace CountTheIntegers
{
	internal class Program
	{
		static void Main()
		{
			int counter = 0;
			while (true)
			{
				string input = Console.ReadLine();
				
				try
				{
					int number = int.Parse(input);
				}
				catch (Exception)
				{
					break;
				}
				counter++;
			}

			Console.WriteLine(counter);
		}
	}
}
namespace VowelsCount
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			PrintNumberOfVowels(input);
		}

		static void PrintNumberOfVowels(string input)
		{
			string vowels = "AEOUIaeoui";
			int counter = 0;
			foreach (char ch in input)
			{
				if (vowels.Contains(ch))
				{
					counter++;
				}
			}

			Console.WriteLine(counter);
		}
	}
}
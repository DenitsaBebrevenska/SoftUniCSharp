namespace EncryptSortAndPrintArray
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int numberOfLines = int.Parse(Console.ReadLine());
			string[] strings = new string[numberOfLines];
			int[] numbers = new int[numberOfLines];
			string vowels = "AIEOUaieou";
			for (int i = 0; i < numberOfLines; i++) //populate the strings[]
			{
				strings[i] = Console.ReadLine();
			}
			int sum = 0; 
			for (int i = 0; i < strings.Length; i++) // go through each string in strings
			{
				for (int j = 0; j < strings[i].Length; j++) //go through each char in a string
				{
					char c = strings[i][j];
					int currentChar = 0;
					if (vowels.Contains(c))
					{
						currentChar = c;
						sum += currentChar * strings[i].Length;
					}
					else
					{ 
						currentChar = c;
						sum += currentChar / strings[i].Length;
					}
				}
				numbers[i] = sum;
                sum = 0;
			}
			Array.Sort(numbers);
			foreach (int i in numbers)
			{
				Console.WriteLine(i);
			}
		}
	}
}
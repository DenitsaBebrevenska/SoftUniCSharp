namespace TriplesOfLatinLetters
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); // n = letter of latin alphabet
			int end = n + 96;
			//97 - 122 is a to z
			for (int i = 97; i <= end; i++)
			{ 
				char charI = (char)i;
				for (int j = 97; j <= end; j++)
				{
					char charJ = (char)j;

					for (int k = 97; k <= end; k++)
					{
						char charK = (char)k;
						Console.WriteLine($"{charI}{charJ}{charK}");
					}
					
                }
				
            }
		}
	}
}
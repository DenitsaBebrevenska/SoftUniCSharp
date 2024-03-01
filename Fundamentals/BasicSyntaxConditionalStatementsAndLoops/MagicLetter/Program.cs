namespace MagicLetter
{
	internal class Program
	{
		static void Main()
		{
			char firstLetter = Console.ReadLine()[0];
			char secondLetter = Console.ReadLine()[0];
			char ignoreLetter = Console.ReadLine()[0];

			for (int i = firstLetter; i <= secondLetter; i++)
			{
				for (int j = firstLetter; j <= secondLetter; j++)
				{
					for (int k = firstLetter; k <= secondLetter; k++)
					{
						if (i == ignoreLetter || j == ignoreLetter || k == ignoreLetter)
						{
							continue;
						}

						Console.Write($"{(char)i}{(char)j}{(char)k} ");
					}
				}
			}
		}
	}
}
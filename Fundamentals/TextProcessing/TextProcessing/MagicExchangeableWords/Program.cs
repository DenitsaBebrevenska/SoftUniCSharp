namespace MagicExchangeableWords
{
	internal class Program
	{
		static void Main()
		{
			string[] words = Console.ReadLine().Split();
			Console.WriteLine(areMagicWords(words).ToString().ToLower());
		}

		private static bool areMagicWords(string[] words)
		{
			char[] charWord1 = words[0].ToCharArray();
			char[] charWord2 = words[1].ToCharArray();
			List<char> uniqueChars1 = new List<char>();
			List<char> uniqueChars2 = new List<char>();

			foreach (char character in charWord1)
			{
				if (!uniqueChars1.Contains(character))
				{
					uniqueChars1.Add(character);
				}
			}

			foreach (char character in charWord2)
			{
				if (!uniqueChars2.Contains(character))
				{
					uniqueChars2.Add(character);
				}
			}

			return uniqueChars1.Count == uniqueChars2.Count;
		}
	}
}

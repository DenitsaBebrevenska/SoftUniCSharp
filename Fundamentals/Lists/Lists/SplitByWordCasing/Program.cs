namespace SplitByWordCasing
{
	internal class Program
	{
		static void Main()
		{
			string[] text = Console.ReadLine().
				Split(new char[]{',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' }, StringSplitOptions.RemoveEmptyEntries);
			List<string> lowerCaseWords = new List<string>();
			List<string> upperCaseWords = new List<string>();
			List<string> mixedCaseWords = new List<string>();
			
			foreach (string word in text)
			{
				bool isLower = false;
				bool isUpper = false;
				bool isMixed = false;

				foreach (char c in word)
				{
					if (char.IsLower(c))
					{
						isLower = true;
					}
					else if (char.IsUpper(c))
					{
						isUpper = true;
					}
					else
					{
						isMixed = true;
					}
				}

				if (isLower && !isUpper && !isMixed)
				{
					lowerCaseWords.Add(word);
				}
				else if (!isLower && isUpper && !isMixed)
				{
					upperCaseWords.Add(word);
				}
				else
				{
					mixedCaseWords.Add(word);
				}
			}

			Console.WriteLine($"Lower-case: {string.Join(", ", lowerCaseWords)}");
			Console.WriteLine($"Mixed-case: {string.Join(", ", mixedCaseWords)}");
			Console.WriteLine($"Upper-case: {string.Join(", ", upperCaseWords)}");
		}
	}
}

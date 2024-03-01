namespace Palindromes
{
	internal class Program
	{
		static void Main()
		{
			char[] delimiters = { ' ', ',', '.', '?', '!' };
			string[] words = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
			List<string> palindromes = new List<string>();

			foreach (string word in words)
			{
				string reversedWord = new string(word.ToCharArray().Reverse().ToArray());
				if (word == reversedWord)
				{
					palindromes.Add(word);
				}
			}

			palindromes = palindromes.Distinct().ToList();
			palindromes.Sort();
			Console.WriteLine(string.Join(", ", palindromes));
		}
	}
}

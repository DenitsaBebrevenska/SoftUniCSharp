using System.Text.RegularExpressions;

namespace ExtractSentencesByKeyword
{
	internal class Program
	{
		static void Main()
		{
			string lookupWord = Console.ReadLine();
			string[] sentences = Console.ReadLine().Split(new char[] { '.', '?', '!' });
			string wordPattern = "\\b" + lookupWord + "\\b";

			foreach (string sentence in sentences)
			{
				Match match = Regex.Match(sentence, wordPattern);

				if (match.Success)
				{
					Console.WriteLine(sentence.Trim());
				}
			}
			
		}
	}
}

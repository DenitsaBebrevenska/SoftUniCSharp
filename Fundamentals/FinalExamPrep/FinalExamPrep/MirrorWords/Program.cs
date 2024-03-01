using System.Text;
using System.Text.RegularExpressions;
namespace MirrorWords
{
	internal class Program
	{
		static void Main()
		{
			string filterPattern = @"([@#])(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})";
			string input = Console.ReadLine();
			StringBuilder mirrorWords = new StringBuilder();
			MatchCollection matches = Regex.Matches(input, filterPattern);
			foreach (Match match in matches)
			{
				string word1 = match.Groups["word1"].Value;
				string word2 = match.Groups["word2"].Value;
				string reversedWord2 = new string(word2.ToCharArray().Reverse().ToArray());
				if (word1.Equals(reversedWord2))
				{
					mirrorWords.Append($"{word1} <=> {word2}, ");
				}
			}

			Console.WriteLine(matches.Count == 0 ? "No word pairs found!" : $"{matches.Count} word pairs found!");
			if (mirrorWords.Length == 0)
			{
				Console.WriteLine("No mirror words!");
				return;
			}

			mirrorWords = mirrorWords.Remove(mirrorWords.Length - 2, 2);
			Console.WriteLine($"The mirror words are: \n{mirrorWords}");
			
		}
	}
}
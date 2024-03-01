using System.Text.RegularExpressions;

namespace PostOffice
{
	internal class Program
	{
		static void Main()
		{
			string[] input = Console.ReadLine().Split('|');
			Dictionary<char, int> wordClues = new Dictionary<char, int>();
			string filerFirstPart = @"([#$%*&]+)(?<letters>[A-Z]+)\1";
			string filterSecondPart = @"(?<ascii>[\d]{2}):(?<length>[\d]{2})";

			string[] words = input[2].Split();

			Match capitalLetters = Regex.Match(input[0], filerFirstPart);
			foreach (char character in capitalLetters.Groups["letters"].Value)
			{
				wordClues.Add(character, 0);
			}

			MatchCollection asciiCodes = Regex.Matches(input[1], filterSecondPart);

			foreach (Match match in asciiCodes) 
			{
				char asciiChar = (char)int.Parse(match.Groups["ascii"].Value);
				int length = int.Parse(match.Groups["length"].Value) + 1;

				if (wordClues.ContainsKey(asciiChar))
				{
					wordClues[asciiChar] = length;
				}
			}

			foreach (var kvp in wordClues) //has to be printed in order of appearance of the chars not the words
			{
				foreach (string word in words)
				{
					if (word[0] == kvp.Key && word.Length == kvp.Value)
					{
						Console.WriteLine(word);
					}
				}
			}
		}
	}
}
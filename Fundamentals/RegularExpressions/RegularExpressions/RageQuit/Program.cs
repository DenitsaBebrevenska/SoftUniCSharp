using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			string pattern = @"(?<string>\D+)(?<count>\d+)";
			MatchCollection matches = Regex.Matches(input, pattern);
			
			StringBuilder sb = new StringBuilder();
			foreach (Match match in matches)
			{
				string stringToUpper = match.Groups["string"].Value.ToUpper();
				int repeatCount = int.Parse(match.Groups["count"].Value);
				for (int i = 0; i < repeatCount; i++)
				{
					sb.Append(stringToUpper);
				}
			}

			string removedRepeatedCharacters = RemoveRepeatingCharacters(sb.ToString());
			int uniqueCharsCount = removedRepeatedCharacters.Length;

			Console.WriteLine($"Unique symbols used: {uniqueCharsCount}");
			Console.WriteLine(sb);
		}

		static string RemoveRepeatingCharacters(string text)
		{
			string result = string.Empty;
			for (int i = 0; i < text.Length; i++)
			{
				if (!result.Contains(text[i]))
				{
					result += text[i];
				}
			}
			return result;
		}
	}
}
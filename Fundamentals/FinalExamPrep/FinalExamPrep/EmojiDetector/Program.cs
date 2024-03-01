using System.Numerics;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
	internal class Program
	{
		static void Main()
		{
			string emojiPattern = @"(:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
			string text = Console.ReadLine();

			MatchCollection matchedEmojies = Regex.Matches(text, emojiPattern);
			MatchCollection matchedDigits = Regex.Matches(text, @"\d");
			long coolThreshold = 1;
			foreach (Match digit in matchedDigits)
			{
				coolThreshold *= long.Parse(digit.Value);
			}

			Console.WriteLine($"Cool threshold: {coolThreshold}");
			Console.WriteLine($"{matchedEmojies.Count} emojis found in the text. The cool ones are:");

			foreach (Match emoji in matchedEmojies.Where(x => x.Groups["emoji"].Value.
				         ToCharArray().
				         Sum(c=>c) >= coolThreshold))
			{
				Console.WriteLine(emoji.Value);
			}
		}
	}
}
using System.Text.RegularExpressions;

namespace PunctuationFinder
{
	internal class Program
	{
		static void Main()
		{
			string text = File.ReadAllText(@"E:\txt\sample_text.txt");
			string regex = @"[.,!?:]";
			MatchCollection punctuationMarks = Regex.Matches(text, regex);

			Console.WriteLine(string.Join(", ", punctuationMarks));
		}
	}
}

using System.Text.RegularExpressions;

namespace MatchNumbers
{
	internal class Program
	{
		static void Main()
		{
			string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
			string input = Console.ReadLine();

			MatchCollection matches = Regex.Matches(input, pattern);

			Console.WriteLine(string.Join(" ", matches));
		}
	}
}

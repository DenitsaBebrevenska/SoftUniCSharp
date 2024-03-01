using System.Text.RegularExpressions;

namespace MatchHexadecimalNumbers
{
	internal class Program
	{
		static void Main()
		{
			string pattern = @"\b(0x)*[A-F0-9]+\b";
			string input = Console.ReadLine();

			MatchCollection matches = Regex.Matches(input, pattern);
			Console.WriteLine(string.Join(" ", matches));
		}
	}
}

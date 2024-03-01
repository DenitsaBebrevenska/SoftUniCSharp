using System.Text.RegularExpressions;

namespace MatchFullName
{
	internal class Program
	{
		static void Main()
		{
			string text = Console.ReadLine();
			string regexFullName = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
			//matches full name: One Upper case letter followed by one or many lower case + whitespace + one upper + at least 1 lower
			MatchCollection matches = Regex.Matches(text, regexFullName);

			foreach (Match match in matches)
			{
				Console.Write(match + " ");
			}
		}
	}
}
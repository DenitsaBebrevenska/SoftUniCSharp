using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
	internal class Program
	{
		static void Main()
		{
			string phoneNumbers = Console.ReadLine();
			string regexCorrectNumber = @"\+359( |-)2\1\d{3}\1\d{4}\b";

			MatchCollection matches = Regex.Matches(phoneNumbers, regexCorrectNumber);

			Console.WriteLine(string.Join(", ", matches));
		}
	}
}
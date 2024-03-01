using System.Text.RegularExpressions;

namespace ExtractEmails
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			string filterEmails = @"\s(?<user>[a-z0-9]+[._-]?[a-z0-9]+)@(?<host>[a-z]+-?[a-z]+(\.[a-z]+)+)";
			//absolutely lost on how to remove the option to start the email with -._, so I`ll add whitespace char and then remove it
			//and that actually worked a charm!

			MatchCollection matches = Regex.Matches(input, filterEmails);

			foreach (Match match in matches)
			{
				string email = match.Value.Trim();
                Console.WriteLine(email);
            }
		}
	}
}
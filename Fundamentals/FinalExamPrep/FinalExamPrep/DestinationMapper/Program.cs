using System.Text.RegularExpressions;

namespace DestinationMapper
{
	internal class Program
	{
		static void Main()
		{
			string validDestinationsPattern = @"([=/])(?<destination>[A-Z][A-Za-z]{2,})\1";
			List<string> destinationList = new List<string>();
			string input = Console.ReadLine();

			MatchCollection matches = Regex.Matches(input, validDestinationsPattern);
			int travelPoints = matches.Sum(x => x.Groups["destination"].Value.Length);
			foreach (Match match in matches)
			{
				destinationList.Add(match.Groups["destination"].Value);
			}

			Console.WriteLine($"Destinations: {string.Join(", ", destinationList)}");
			Console.WriteLine($"Travel Points: {travelPoints}");
		}
	}
}
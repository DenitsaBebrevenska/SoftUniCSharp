using System.Text.RegularExpressions;

namespace СръбскоUnleashed
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<string,List<Concert>> concertMap = new Dictionary<string,List<Concert>>();
			string correctPattern =
				@"(?<singer>[A-Za-z]+( [A-Za-z]+)*) @(?<location>[A-Za-z]+( [A-Za-z]+)*) (?<ticketPrice>\d+) (?<ticketCount>\d+)";

			string input;

			while ((input = Console.ReadLine()) != "End")
			{
				Match match = Regex.Match(input, correctPattern);

				if (!match.Success)
				{
					continue;
				}

				string singer = match.Groups["singer"].Value;
				string location = match.Groups["location"].Value;
				uint ticketPrice = uint.Parse(match.Groups["ticketPrice"].Value);
				uint ticketCount = uint.Parse(match.Groups["ticketCount"].Value);

				if (!concertMap.ContainsKey(location))
				{
					concertMap.Add(location, new List<Concert>());
				}

				int index = concertMap[location].FindIndex(c => c.Singer == singer);

				if (index < 0)
				{
					concertMap[location].Add(new Concert(singer, ticketPrice * ticketCount));
				}
				else
				{
					concertMap[location][index].TotalGain += ticketPrice * ticketCount;
				}
			}

			foreach (var kvp in concertMap)
			{
				Console.WriteLine($"{kvp.Key}");

				foreach (Concert c in kvp.Value.OrderByDescending(c => c.TotalGain))
				{
					Console.WriteLine($"#  {c.Singer} -> {c.TotalGain}");
				}
			}
		}
	}
}

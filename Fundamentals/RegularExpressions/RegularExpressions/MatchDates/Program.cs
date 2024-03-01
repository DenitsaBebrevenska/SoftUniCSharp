using System.Text.RegularExpressions;

namespace MatchDates
{
	internal class Program
	{
		static void Main()
		{
			string dates = Console.ReadLine();
			string regexDate = @"\b(?<day>\d{2})(/|-|.)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

			MatchCollection dateCollection = Regex.Matches(dates, regexDate);

			foreach (Match date in dateCollection)
			{
				var groups = date.Groups;
				Console.WriteLine($"Day: {groups["day"].Value}, Month: {groups["month"].Value}," +
				                  $" Year: {groups["year"].Value}");
			}
		}
	}
}
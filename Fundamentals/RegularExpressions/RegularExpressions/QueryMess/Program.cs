using System.Text;
using System.Text.RegularExpressions;

namespace QueryMess
{
	internal class Program
	{
		static string pattern = @"(?<key>\S+)=(?<value>\S+)";
		static void Main()
		{
			string input;
			StringBuilder queryConverted = new StringBuilder();
			while ((input = Console.ReadLine()) != "END")
			{
				Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>();
				string[] currentQuery = input.Split(new char[] { '&', '?' });
				string whitespacePattern = @"\+|%20";
				foreach (string queryPiece in currentQuery)
				{
					MatchCollection matches = Regex.Matches(queryPiece, pattern);

					if (matches.Count > 0)
					{
						foreach (Match match in matches)
						{
							string key = match.Groups["key"].Value;
							key = Regex.Replace(key, whitespacePattern, " ");
							key = Regex.Replace(key, " {2,}"," ").Trim();
							string value = match.Groups["value"].Value;
							value = Regex.Replace(value, whitespacePattern, " ");
							value = Regex.Replace(value, " {2,}", " ").Trim();

							if (!keyValuePairs.ContainsKey(key))
							{
								keyValuePairs.Add(key, new List<string>());
							}

							keyValuePairs[key].Add(value);
						}
					}
				}

				foreach (var kvp in keyValuePairs)
				{
					queryConverted.Append($"{kvp.Key}=[{string.Join(", ", kvp.Value)}]");
				}

				queryConverted.Append('\n');
			}

			Console.WriteLine(queryConverted.ToString());
		}
	}
}

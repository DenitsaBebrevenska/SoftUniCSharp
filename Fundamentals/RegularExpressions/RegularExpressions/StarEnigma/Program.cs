using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
	internal class Program
	{
		static void Main()
		{ 
			int numberOfMessages = int.Parse(Console.ReadLine());
			List<string> attackedPlanets = new List<string>();
			List<string> destroyedPlanets = new List<string>();
			for (int i = 0; i < numberOfMessages; i++)
			{
				string currentMessage = Console.ReadLine();
				string tokensPattern =
					@"@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@:!\->]*!(?<action>A|D)![^@:!\->]*->(?<soldiers>\d+)";
				string decryptedMessage = DecryptMessage(currentMessage);
				Match match = Regex.Match(decryptedMessage, tokensPattern);

				if (!match.Success)
				{
					continue;
				}

				if (match.Groups["action"].Value == "D")
				{
					destroyedPlanets.Add(match.Groups["planet"].Value);
				}
				else
				{
					attackedPlanets.Add(match.Groups["planet"].Value);
				}
				
			}

			PrintAttackedPlanets(attackedPlanets);
			PrintDestroyedPlanets(destroyedPlanets);
		}

		static void PrintAttackedPlanets(List<string> attackedPlanets)
		{
			Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

			foreach (string planet in attackedPlanets.OrderBy(x => x))
			{
				Console.WriteLine($"-> {planet}");
			}
		}

		static void PrintDestroyedPlanets(List<string> destroyedPlanets)
		{
			Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
			foreach (string planet in destroyedPlanets.OrderBy(x => x))
			{
				Console.WriteLine($"-> {planet}");
			}
		}

		static int GetLetterCount(string currentMessage)
		{
			string regexPattern = "[STARstar]";
			MatchCollection matches = Regex.Matches(currentMessage, regexPattern);
			return matches.Count;
		}
		static string DecryptMessage(string currentMessage)
		{
			StringBuilder sb = new StringBuilder();
			int count = GetLetterCount(currentMessage);

			foreach (char symbol in currentMessage)
			{
				sb.Append((char)(symbol - count));
			}
			return sb.ToString();
		}
	}
}
using System.Text.RegularExpressions;

namespace ValidUsernames
{
	internal class Program
	{
		static string patternExclusion = @"^[A-Za-z]{1}\w{2,24}$";

		static void Main()
		{
			string[] usernames = Console.ReadLine().Split(new char[] { ' ', '\\', '/', '(', ')' },
				StringSplitOptions.RemoveEmptyEntries);

			List<string> validUsernames = GetValidUsernames(usernames);

			string[] longestConsecutiveUsernames = GetLongestConsecutiveUsernames(validUsernames);

			Console.WriteLine(longestConsecutiveUsernames[0] + "\n" + longestConsecutiveUsernames[1]);
		}

		static List<string> GetValidUsernames(string[] usernames)
		{
			List<string> validUsernames = new List<string>();
			foreach (string username in usernames)
			{
				Match matchPattern = Regex.Match(username, patternExclusion);

				if (!matchPattern.Success)
				{
					continue;
				}

				validUsernames.Add(username);
			}

			return validUsernames;
		}

		static string[] GetLongestConsecutiveUsernames(List<string> validUsernames)
		{
			string[] longestConsecutiveUsernames = new string[2];
			int maxLength = 0;

			for (int i = 0; i < validUsernames.Count - 1; i++)
			{
				if (validUsernames[i].Length + validUsernames[i + 1].Length > maxLength)
				{
					longestConsecutiveUsernames[0] = validUsernames[i];
					longestConsecutiveUsernames[1] = validUsernames[i + 1];
					maxLength = validUsernames[i].Length + validUsernames[i + 1].Length;
				}
			}

			return longestConsecutiveUsernames;
		}

	}
}

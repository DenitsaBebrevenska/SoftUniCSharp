using System.Text;
using System.Text.RegularExpressions;

namespace SantasSecretHelper
{
	internal class Program
	{
		static void Main()
		{
			int key = int.Parse(Console.ReadLine());
			string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behaviour>[G|N])!";
			List<string> goodChildren = new List<string>();
			string input;

			while ((input = Console.ReadLine()) != "end")
			{
				string decryptedMessage = DecryptMessage(input,key);
				Match match = Regex.Match(decryptedMessage, pattern);

				if (match.Groups["behaviour"].Value == "G")
				{
					goodChildren.Add(match.Groups["name"].Value);
				}
			}

			goodChildren.Select(x =>x).ToList().ForEach(x => Console.WriteLine(x));
		}

		static string DecryptMessage(string encryptedMessage, int key)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char character in encryptedMessage)
			{
				sb.Append((char)(character - key));
			}
			return sb.ToString();
		}
	}
}
using System.Text.RegularExpressions;

namespace KeyReplacer
{
	internal class Program
	{
		static void Main()
		{
			string keys = Console.ReadLine();
			string text = Console.ReadLine();
			string startKey = GetStartKey(keys);
			string endKey = GetEndKey(keys);
			string filter = $"{startKey}(?<word>(?!{endKey})(.*?)){endKey}";
			MatchCollection matches = Regex.Matches(text, filter);
			string output = string.Empty;

			foreach (Match match in matches)
			{
				output += match.Groups["word"].Value;
			}

			Console.WriteLine(output == string.Empty ? "Empty result" : $"{output}");
		}

		static string GetStartKey(string keys)
		{
			string key = string.Empty;

			for (int i = 0; i < keys.Length; i++)
			{
				if (IsSpecialChar(keys[i]))
				{
					break;
				}

				key += keys[i];
			}

			return key;
		}
		static string GetEndKey(string keys)
		{
			string key = string.Empty;

			for (int i = keys.Length - 1; i >= 0; i--)
			{

				if (IsSpecialChar(keys[i]))
				{
					break;
				}

				key += keys[i];
			}

			return new string(key.ToCharArray().Reverse().ToArray());
		}

		static bool IsSpecialChar(char character)
		{
			return character == '|' || character == '<' || character == '\\';
		}
	}
}

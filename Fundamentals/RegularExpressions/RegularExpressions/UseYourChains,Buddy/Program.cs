using System.Text; 
using System.Text.RegularExpressions;

namespace UseYourChains_Buddy
{
	internal class Program
	{
		static void Main()
		{
			string encryptedMessage = Console.ReadLine();
			string patternInstructions = @"<p>(?<instruction>(.*?))</p>";
			string patternToReplace = @"[^a-z\d]+";
			StringBuilder decryptedMessage = new StringBuilder();
			MatchCollection matches = Regex.Matches(encryptedMessage, patternInstructions);

			foreach (Match match in matches)
			{
				string currentInstruction = match.Groups["instruction"].Value;
				currentInstruction = Regex.Replace(currentInstruction, patternToReplace, " ");

				for (int i = 0; i < currentInstruction.Length; i++)
				{
					char charToAppend = currentInstruction[i];

					if (charToAppend == ' ' || char.IsDigit(charToAppend))
					{
						decryptedMessage.Append(charToAppend);
						continue;
					}

					if (charToAppend >= 97 && charToAppend < 110)
					{
						decryptedMessage.Append((char)(charToAppend + 13));
					}
					else
					{
						decryptedMessage.Append((char)(charToAppend - 13));
					}

				}
			}
			Console.WriteLine(decryptedMessage.ToString());
		}
	}
}

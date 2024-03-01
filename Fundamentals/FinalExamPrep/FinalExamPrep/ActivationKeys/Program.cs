using System;

namespace ActivationKeys
{
	internal class Program
	{
		static void Main()
		{
			string rawKey = Console.ReadLine();
			string command;

			while ((command = Console.ReadLine()) != "Generate")
			{
				string[] commandDetails = command.Split(">>>");
				switch (commandDetails[0])
				{
					case "Contains":
						string substring = commandDetails[1];
						Console.WriteLine(rawKey.Contains(substring) ? $"{rawKey} contains {substring}" : "Substring not found!");
						continue;
						break;
					case "Flip":
						rawKey = FlipText(rawKey,commandDetails);
						break;
					case "Slice":
						int startingIndex = int.Parse(commandDetails[1]);
						int endingIndex = int.Parse(commandDetails[2]);
						rawKey = rawKey.Remove(startingIndex, endingIndex - startingIndex);
						break;
				}

				Console.WriteLine(rawKey);
			}

			Console.WriteLine($"Your activation key is: {rawKey}");
		}

		static string FlipText(string rawKey, string[] commandDetails)
		{
			string change = commandDetails[1];
			int startIndex = int.Parse(commandDetails[2]);
			int endIndex = int.Parse(commandDetails[3]);
			string extractedSubstring = rawKey.Substring(startIndex, endIndex - startIndex);
			if (change == "Upper")
			{
				extractedSubstring = extractedSubstring.ToUpper();
			}
			else
			{
				extractedSubstring = extractedSubstring.ToLower();
			}

			rawKey = rawKey.Remove(startIndex, endIndex - startIndex);
			rawKey = rawKey.Insert(startIndex, extractedSubstring);
			return rawKey;
		}
	}
}
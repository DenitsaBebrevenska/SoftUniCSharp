using System.Text.RegularExpressions;

namespace Hideout
{
	internal class Program
	{
		static void Main()
		{
			string map = Console.ReadLine();
			bool hideoutFound = false;

			while (!hideoutFound)
			{
				string[] clues = Console.ReadLine().Split();
				string symbol = clues[0];
				int minimumCount = int.Parse(clues[1]);
				string hideoutPattern = @$"\{symbol}{{{minimumCount},}}";
				Match match = Regex.Match(map, hideoutPattern);

				if (match.Success)
				{
					hideoutFound = true;
					string hideoutString = match.Groups[0].Value;
					int index = map.IndexOf(hideoutString);
					int lengthString = hideoutString.Length;
					Console.WriteLine($"Hideout found at index {index} and it is with size {lengthString}!");
				}
			}
		}
	}
}

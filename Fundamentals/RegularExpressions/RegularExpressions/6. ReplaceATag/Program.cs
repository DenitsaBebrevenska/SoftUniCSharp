using System.Text.RegularExpressions;

namespace _6._ReplaceATag
{
	internal class Program
	{
		static void Main()
		{
			
			string input;

			while ((input = Console.ReadLine()) != "end")
			{
				if (input.Contains("<a"))
				{
					string firstFix = Regex.Replace(input, "<a", "[URL");
					string secondFix = Regex.Replace(firstFix, "\">", "\"]");
					string finalFix = Regex.Replace(secondFix, "</a>", "[/URL]");
					Console.WriteLine(finalFix);
					continue;
				}

				Console.WriteLine(input);
			}
		}
	}
}

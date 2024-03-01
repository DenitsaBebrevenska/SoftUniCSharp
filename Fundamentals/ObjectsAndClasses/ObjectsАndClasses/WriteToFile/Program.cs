using System.Text.RegularExpressions;

namespace WriteToFile
{
	internal class Program
	{
		static void Main()
		{
			string text = File.ReadAllText(@"E:\txt\sample_text.txt");
			string regex = @"[.,!?:]";
			string replacedText = Regex.Replace(text, regex, "");
			string path = @"E:\txt\new_text.txt";

			File.WriteAllText(path, replacedText);
			
		}
	}
}

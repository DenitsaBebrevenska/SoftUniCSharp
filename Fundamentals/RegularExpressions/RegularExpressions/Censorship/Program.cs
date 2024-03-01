namespace Censorship
{
	internal class Program
	{
		static void Main()
		{
			string wordToCensor = Console.ReadLine();
			string text = Console.ReadLine();
			string censoredWord = new string('*', wordToCensor.Length);
			text = text.Replace(wordToCensor, censoredWord);

			Console.WriteLine(text);
		}
	}
}

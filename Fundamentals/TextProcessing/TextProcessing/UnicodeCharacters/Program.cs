namespace UnicodeCharacters
{
	internal class Program
	{
		static void Main()
		{
			string text = Console.ReadLine();

			for (int i = 0; i < text.Length; i++)
			{
				Console.Write($"\\u{(int)text[i]:x4}");
			}
		}
	}
}

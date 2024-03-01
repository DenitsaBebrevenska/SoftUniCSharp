namespace IndexOfLetters
{
	internal class Program
	{
		static void Main()
		{
			char[] word = Console.ReadLine().ToCharArray();

			foreach (char letter in word)
			{
				Console.WriteLine($"{letter} -> {letter - 97}");
			}
		}
	}
}
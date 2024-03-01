namespace Substring_RefactoringExercise
{
	internal class Program
	{
		public static void Main()
		{
			string text = Console.ReadLine();
			int count = int.Parse(Console.ReadLine());

			char letter = 'p';
			bool hasMatch = false;

			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == letter)
				{
					hasMatch = true;
					int length = 0;

					if (i + count >= text.Length)
					{
						length = text.Length - i;
					}
					else
					{
						length = count + 1;
					}

					string matchedString = text.Substring(i, length);
					Console.WriteLine(matchedString);
					i += count;
				}
			}

			if (!hasMatch)
			{
				Console.WriteLine("no");
			}
		}
	}
}
using System.Text;

namespace MorseCodeTranslator
{
	internal class Program
	{
		static void Main()
		{
			string[] morseMessage = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < morseMessage.Length; i++)
			{
				string[] currentWord = morseMessage[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
				foreach (string letter in currentWord)
				{
					Console.Write(GetLetter(letter));
				}

				Console.Write(' ');
			}
		}

		static char GetLetter(string morseCodeLetter)
		{
			SortedDictionary<string, char> morseCode = new SortedDictionary<string, char>()
			{
				{".-", 'A'},
				{"-...", 'B'},
				{"-.-.", 'C'},
				{"-..", 'D'},
				{".", 'E'},
				{"..-.", 'F'},
				{"--.", 'G'},
				{"....", 'H'},
				{"..", 'I'},
				{".---", 'J'},
				{"-.-", 'K'},
				{".-..", 'L'},
				{"--", 'M'},
				{"-.", 'N'},
				{"---", 'O'},
				{".--.", 'P'},
				{"--.-", 'Q'},
				{".-.", 'R'},
				{"...", 'S'},
				{"-", 'T'},
				{"..-", 'U'},
				{"...-", 'V'},
				{".--", 'W'},
				{"-..-", 'X'},
				{"-.--", 'Y'},
				{"--..", 'Z'}
			};
			return morseCode[morseCodeLetter];
		}
	}
}
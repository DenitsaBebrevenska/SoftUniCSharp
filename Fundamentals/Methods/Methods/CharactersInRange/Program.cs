namespace CharactersInRange
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string input1 = Console.ReadLine();
			string input2 = Console.ReadLine();
			char char1 = input1[0];
			char char2 = input2[0];
			GetCharsInRange(char1, char2);
		}

		static void GetCharsInRange(char char1, char char2)
		{
			if (char1 > char2)
			{
				(char1, char2) = (char2, char1);
			}
			for (int i = char1 + 1; i < char2; i++)
			{
				char currentChar = (char)i;
				Console.Write(currentChar + " ");
			}
		}
	}
}
namespace RandomizeWords
{
	internal class Program
	{
		static void Main()
		{
			string[] input = Console.ReadLine().Split();

			input = ScrambleSentence(input);
			PrintOutput(input);
		}
		 
		static string[] ScrambleSentence(string[] input)
		{
			Random random = new Random();

			for (int i = 0; i < input.Length; i++)
			{
				string wordAtIndex = input[i];
				int randomIndex = random.Next(0, input.Length);
				string replacementWord = input[randomIndex];

				input[i] = replacementWord;
				input[randomIndex] = wordAtIndex;
			}
			return input;
		}

		static void PrintOutput(string[] input)
		{
			foreach (string word in input)
			{
				Console.WriteLine(word);
			}
		}
	}
}
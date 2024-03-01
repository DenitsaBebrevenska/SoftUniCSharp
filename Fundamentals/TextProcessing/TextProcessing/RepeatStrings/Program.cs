namespace RepeatStrings
{
	internal class Program
	{
		static void Main()
		{
			string[] stringArray = Console.ReadLine().Split();

			foreach (string word in stringArray)
			{
				for (int i = 0; i < word.Length; i++)
				{
					Console.Write(word);
				}
			}
		}
	}
}
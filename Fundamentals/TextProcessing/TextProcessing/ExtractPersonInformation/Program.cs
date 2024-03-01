namespace ExtractPersonInformation
{
	internal class Program
	{
		static void Main()
		{
			int numberOfLines = int.Parse(Console.ReadLine());

			for (int i = 0; i < numberOfLines; i++)
			{
				string line = Console.ReadLine();
				int indexAt = line.IndexOf('@');
				int indexColumn = line.IndexOf('|');
				string name = line.Substring(indexAt + 1, indexColumn - indexAt - 1);
				int indexHash = line.IndexOf('#');
				int indexAsterisk = line.IndexOf('*');
				string age = line.Substring(indexHash + 1, indexAsterisk - indexHash - 1);

				Console.WriteLine($"{name} is {age} years old.");
			}
		}
	}
}
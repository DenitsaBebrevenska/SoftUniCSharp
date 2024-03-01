namespace ShortWordsSorted
{
	internal class Program
	{
		static void Main()
		{
			List<string> words = Console.ReadLine().Split(new char[]
				{ '.', ',',':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' },  StringSplitOptions.RemoveEmptyEntries).ToList();

			words = words.Select(x => x.ToLower()).OrderBy(x =>x).Where(x => x.Length < 5).Distinct().ToList();

			Console.WriteLine(string.Join(", ", words));
		}
	}
}

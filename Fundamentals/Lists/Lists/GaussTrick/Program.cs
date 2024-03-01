namespace GaussTrick
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split(' ').
				Select(int.Parse).
				ToList();

			for (int i = 0; i < numbers.Count ; i++)
			{
				if (i != numbers.Count - 1)
				{
					numbers[i] += numbers[^1];
					numbers.RemoveAt(numbers.Count - 1);
				}
			}
			Console.WriteLine(string.Join(" ", numbers));
		}
	}
}
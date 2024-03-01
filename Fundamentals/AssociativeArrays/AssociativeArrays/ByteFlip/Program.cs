namespace ByteFlip
{
	internal class Program
	{
		static void Main()
		{
			List<string> numbers = Console.ReadLine().
				Split().
				ToList();

			numbers.RemoveAll(x => x.Length != 2);
			numbers = numbers.Select(x => new string(x.Reverse().ToArray())).ToList();
			List<int> numbersList = numbers.Select(x => Convert.ToInt32(x, 16)).ToList();
			numbersList.Reverse();
			char[] charactersAscii = numbersList.Select(x => Convert.ToChar(x)).ToArray();

			Console.WriteLine(string.Join("",charactersAscii));
		}
	}
}

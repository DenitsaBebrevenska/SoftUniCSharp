namespace ReverseAString
{
	internal class Program
	{
		static void Main()
		{
			Stack<char> wordCharacters = new Stack<char>(Console.ReadLine().ToCharArray());
			Console.WriteLine(string.Join("", wordCharacters));
		}
	}
}

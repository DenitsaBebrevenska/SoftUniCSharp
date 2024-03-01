namespace RepeatString
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			int number = int.Parse(Console.ReadLine());
			Console.WriteLine(RepeatString(input, number));
		}
		static string RepeatString(string text, int number)
		{
			string result = string.Empty;
			for (int i = 1; i <= number; i++)
			{
				result += text;
			}
			return result;
		}
	}
}
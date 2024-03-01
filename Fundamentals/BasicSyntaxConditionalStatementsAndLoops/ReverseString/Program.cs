using System.Text;

namespace ReverseString
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			Console.WriteLine(ReverseString(input));
		}
		static string ReverseString(string input)
		{
			StringBuilder reversed = new StringBuilder();
			for (int i = input.Length - 1; i >= 0; i--)
			{
				reversed.Append(input[i]);
			}
			return reversed.ToString();
		}
	}
}
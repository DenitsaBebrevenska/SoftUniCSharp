namespace VowelOrDigit
{
	internal class Program
	{
		static void Main()
		{
			string symbol = Console.ReadLine();

			if (IsVowel(symbol))
			{
				Console.WriteLine("vowel");
			}
			else if (IsDigit(symbol))
			{
				Console.WriteLine("digit");
			}
			else
			{
				Console.WriteLine("other");
			}
		}

		static bool IsVowel(string symbol)
		{
			symbol = symbol.ToLower();
			return symbol == "a" || symbol == "e" || symbol == "i" || symbol == "o" || symbol == "u";
		}

		static bool IsDigit(string symbol)
		{
			try
			{
				int number = int.Parse(symbol);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
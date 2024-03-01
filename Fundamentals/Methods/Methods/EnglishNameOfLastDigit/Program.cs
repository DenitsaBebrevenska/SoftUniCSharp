namespace EnglishNameOfLastDigit
{
	internal class Program
	{
		static void Main()
		{
			string number = Console.ReadLine();
			Console.WriteLine(GetLastDigitName(number));
		}
		static string GetLastDigitName(string number)
		{
			switch (number[^1])
			{
				case '1':
					return "one";
				case '2':
					return "two";
				case '3':
					return "three";
				case '4':
					return "four";
				case '5':
					return "five";
				case '6':
					return "six";
				case '7':
					return "seven";
				case '8':
					return "eight";
				case '9':
					return "nine";
				case '0':
					return "zero";
			}

			return null;
		}
	}
}

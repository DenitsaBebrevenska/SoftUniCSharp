namespace PalindromeIntegers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string number;
			
			while ((number = Console.ReadLine()) != "END")
			{
				bool isPalindrome = CheckPalindrome(number);
				Console.WriteLine(isPalindrome.ToString().ToLower());
			}
		}

		static string ReverseString(string number)
		{
			int lenght = number.Length;
			string reversedString = string.Empty;
			for (int i = lenght -1; i >= 0; i--)
			{
				char currentChar = number[i];
				reversedString += currentChar;
			}

			return reversedString;
		}

		static bool CheckPalindrome(string number1)
		{
			string reversedString = ReverseString(number1);
			if (number1.Equals(reversedString))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
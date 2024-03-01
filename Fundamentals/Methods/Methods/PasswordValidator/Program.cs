namespace PasswordValidator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string password = Console.ReadLine();
			CheckPassword(password);
		}

		static void CheckPassword(string password)
		{
			bool isValidLenght = ValidatePasswordLenght(password);
			bool hasValidChar = ValidatePasswordCharacters(password);
			bool hasEnoughDigits = ValidatePasswordDigits(password);

			if (!isValidLenght)
			{
				Console.WriteLine("Password must be between 6 and 10 characters");
			}

			if (!hasValidChar)
			{
				Console.WriteLine("Password must consist only of letters and digits");
			}

			if (!hasEnoughDigits)
			{
				Console.WriteLine("Password must have at least 2 digits");
			}

			if (isValidLenght && hasEnoughDigits && hasValidChar)
			{
				Console.WriteLine("Password is valid");
			}
		}

		static bool ValidatePasswordLenght(string password)
		{
			int lenght = password.Length;
			
			if (lenght >= 6 && lenght <= 10)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		static bool ValidatePasswordCharacters(string password)
		{
			int counterLetters = 0;
			foreach (char ch in password)
			{
				if ((ch >= 48 && ch <= 57) || (ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122))
				{
					counterLetters++;
				}
			}

			int passwordLenght = password.Length;
			if (counterLetters == passwordLenght)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		static bool ValidatePasswordDigits(string password)
		{
			int counter = 0;
			foreach (char ch in password)
			{
				if (char.IsDigit(ch))
				{
					counter++;
				}
			}

			if (counter >= 2)
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
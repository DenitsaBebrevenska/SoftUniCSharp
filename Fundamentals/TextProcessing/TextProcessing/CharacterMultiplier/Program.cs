namespace CharacterMultiplier
{
	internal class Program
	{
		static void Main()
		{
			string[] strings = Console.ReadLine().Split();
			string firstString = strings[0];
			string secondString = strings[1];
			int result = MultiplyCharCodes(firstString, secondString);

			Console.WriteLine(result);
		}

		static int MultiplyCharCodes(string firstString, string secondString)
		{
			int minLength = Math.Min(firstString.Length, secondString.Length);

			int sum = 0;
			for (int i = 0; i < minLength; i++)
			{
				sum += firstString[i] * secondString[i];
			}

			string longerString = GetLongerString(firstString, secondString);

			if (longerString != string.Empty)
			{
				for (int i = minLength ; i < longerString.Length; i++)
				{
					sum += longerString[i];
				}
			}

			return sum;
		}

		static string GetLongerString(string firstString, string secondString)
		{
			if (Equals(firstString,secondString))
			{
				return string.Empty;
			}
			
			return firstString.Length  > secondString.Length ? firstString : secondString;
		}
	}
}
namespace OnlyLetters
{
	internal class Program
	{
		static void Main()
		{
			string message = Console.ReadLine();
			int startIndex = -1;
			int countDigits = 0;
			bool digitFound = false;

			for (int i = 0; i < message.Length; i++)
			{
				if (char.IsDigit(message[i]))
				{
					if (!digitFound)
					{
						startIndex = i;
						digitFound = true;
					}
					countDigits++;
				}
				else
				{
					if (digitFound)
					{
						message = message.Insert(i,new string(message[i], 1));
						message = message.Remove(startIndex, countDigits);
						digitFound = false;
						startIndex = -1;
						countDigits = 0;
					}
				}
			}

			Console.WriteLine(message);
		}
	}
}

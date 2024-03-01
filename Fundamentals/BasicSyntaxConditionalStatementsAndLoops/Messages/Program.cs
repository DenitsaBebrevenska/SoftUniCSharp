using System.Text;

namespace Messages
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); // n - amount of symbols
			string message = string.Empty;
			for (int i = 1; i <= n; i++)
			{
				string input = Console.ReadLine();
				int lenghtInput = input.Length; // number of digits
				char inputDigit = input[0];
				int mainDigit = Convert.ToInt32(inputDigit) - '0'; //or substract 48 /is the ASCI value of zero
				if (mainDigit == 0) // in case 0
				{
					message += (' ');
				}
				else
				{
					int offset = (mainDigit - 2) * 3;
					if (mainDigit == 8 || mainDigit == 9)
					{
						offset += 1;
					}
					int letterIndex = (offset + lenghtInput - 1);
					int letterInt = 'a' + letterIndex;
					char letter = Convert.ToChar(letterInt);

					message += (letter);
				}
			
			}
            Console.WriteLine(message);

        }
		
	}
}
using System.Text;

namespace Login
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string username = Console.ReadLine();
			string password = ReverseString(username);
			string input = Console.ReadLine();
			int counter = 0;
			bool isBlocked = false;
			while (input != password)
			{
				counter++;
				if (counter == 4) // block user at 4th attempt
				{
                    Console.WriteLine($"User {username} blocked!");
					isBlocked = true;
					break;
				}
                Console.WriteLine("Incorrect password. Try again.");
				input = Console.ReadLine();
            }
			if (!isBlocked)
			{
				Console.WriteLine($"User {username} logged in.");
			}

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
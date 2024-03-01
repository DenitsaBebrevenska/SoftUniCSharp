using System;
using System.Text;

namespace PasswordReset
{
	internal class Program
	{
		static void Main()
		{
			string rawPassword = Console.ReadLine();
			string action;

			while ((action = Console.ReadLine()) != "Done")
			{
				string[] actionDetails = action.Split();
				switch (actionDetails[0])
				{
					case "TakeOdd":
						rawPassword = ConcatenateOddCharacters(rawPassword);
						break;
					case "Cut":
						int index = int.Parse(actionDetails[1]);
						int length = int.Parse(actionDetails[2]);
						rawPassword = rawPassword.Remove(index, length);
						break;
					case "Substitute":
						string substring = actionDetails[1];
						string substituteString = actionDetails[2];
						if (!rawPassword.Contains(substring))
						{
							Console.WriteLine("Nothing to replace!");
							continue;
						}
						rawPassword = rawPassword.Replace(substring, substituteString);
						break;
				}
				Console.WriteLine(rawPassword);

			}

			Console.WriteLine($"Your password is: {rawPassword}");
		}

		static string ConcatenateOddCharacters(string text)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 1; i < text.Length; i += 2)
			{
				sb.Append(text[i]);
			}
			return sb.ToString();
		}
	}
}
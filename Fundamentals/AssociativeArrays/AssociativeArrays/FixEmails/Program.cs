namespace FixEmails
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<string, string> emailsMap = new Dictionary<string, string>();

			while (true)
			{
				string name = Console.ReadLine();

				if (name == "stop")
				{
					break;
				}
				string email = Console.ReadLine();
				string[] emailTokens = email.Split(new char[] { '@', '.' });

				if (emailTokens[^1].ToLower() == "us" || emailTokens[^1].ToLower() == "uk")
				{
					continue;
				}

				emailsMap.Add(name, email);
			}

			foreach (var kvp in emailsMap)
			{
				Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
			}
		}
	}
}

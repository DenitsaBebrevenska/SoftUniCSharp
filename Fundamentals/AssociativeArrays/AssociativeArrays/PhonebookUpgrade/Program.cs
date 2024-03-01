namespace PhonebookUpgrade
{
	internal class Program
	{
		static void Main()
		{
			SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();
			string input;

			while ((input = Console.ReadLine()) != "END")
			{
				string[] commandArgs = input.Split();
				string command = commandArgs[0];
				
				switch (command)
				{
					case "A":
						string name = commandArgs[1];
						string phoneNumber = commandArgs[2];

						if (!phonebook.ContainsKey(name))
						{
							phonebook.Add(name, string.Empty);
						}

						phonebook[name] = phoneNumber;
						break;
					case "S":
						name = commandArgs[1];
						if (!phonebook.ContainsKey(name))
						{
							Console.WriteLine($"Contact {name} does not exist.");
							continue;
						}

						Console.WriteLine($"{name} -> {phonebook[name]}");
						break;
					case "ListAll":
						foreach (var kvp in phonebook)
						{
							Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
						}
						break;
				}
			}
		}
	}
}

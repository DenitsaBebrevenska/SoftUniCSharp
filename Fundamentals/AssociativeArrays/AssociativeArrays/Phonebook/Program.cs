namespace Phonebook
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<string, string> phonebook = new Dictionary<string, string>();
			string input;

			while ((input = Console.ReadLine()) != "END")
			{
				string[] commandArgs = input.Split();
				string command = commandArgs[0];
				string name = commandArgs[1];

				switch (command)
				{
					case "A":
						string phoneNumber = commandArgs[2];

						if (!phonebook.ContainsKey(name))
						{
							phonebook.Add(name, string.Empty);
						}

						phonebook[name] = phoneNumber;
						break;
					case "S":

						if (!phonebook.ContainsKey(name))
						{
							Console.WriteLine($"Contact {name} does not exist.");
							continue;
						}

						Console.WriteLine($"{name} -> {phonebook[name]}");
						break;
				}
			}
		}
	}
}

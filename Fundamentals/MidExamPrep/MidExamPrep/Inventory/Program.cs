namespace Inventory
{
	internal class Program
	{
		static void Main()
		{
			List<string> inventory = Console.ReadLine().Split(", ").ToList();

			string input;
			string[] separators = { " - ", ":" };
			while ((input = Console.ReadLine()) != "Craft!")
			{
				string[] action = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

				if (action[0] == "Collect" && !inventory.Contains(action[1]))
				{
					inventory.Add(action[1]);
				}
				else if (action[0] == "Drop" && inventory.Contains(action[1]))
				{
					inventory.Remove(action[1]);
				}
				else if (action[0] == "Combine Items" && inventory.Contains(action[1]))
				{
					int index = inventory.IndexOf(action[1]);
					inventory.Insert(index + 1, action[2]);
				}
				else if (action[0] == "Renew" && inventory.Contains(action[1]))
				{
					inventory.Remove(action[1]);
					inventory.Add(action[1]);
				}
			}

			Console.WriteLine(string.Join(", ", inventory));
		}
	}
}
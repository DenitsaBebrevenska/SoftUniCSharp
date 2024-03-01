using System.Linq;

namespace ShoppingList
{
	internal class Program
	{
		static void Main()
		{
			List<string> products = Console.ReadLine().
				Split('!').
				ToList();
			string command;

			while ((command = Console.ReadLine()) != "Go Shopping!")
			{
				string[] tokens = command.Split().ToArray();

				if (tokens[0] == "Urgent" && !products.Contains(tokens[1]))
				{
					products.Insert(0, tokens[1]);
				}
				else if (tokens[0] == "Unnecessary" && products.Contains(tokens[1]))
				{
					products.Remove(tokens[1]);
				}
				else if (tokens[0] == "Correct" && products.Contains(tokens[1]))
				{
					int index = products.IndexOf(tokens[1]);
					products[index] = tokens[2];
				}
				else if (tokens[0] == "Rearrange" && products.Contains(tokens[1]))
				{
					products.Remove(tokens[1]);
					products.Add(tokens[1]);
				}
			}

			Console.WriteLine(string.Join(", ", products));
		}
	}
}
using System.Text.RegularExpressions;

namespace Furniture
{
	internal class Program
	{
		static void Main()
		{
			string input;
			List<string> boughtItems = new List<string>();
			double totalPrice = 0;

			while ((input = Console.ReadLine()) != "Purchase")
			{
				string regexFurniture = @">>(?<name>[A-z]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";
				//">>{furniture name}<<{price}!{quantity}" price could be floating point or not
				Match match = Regex.Match(input, regexFurniture);
				if (!match.Success)
				{
					continue;
				}
				double price = double.Parse(match.Groups["price"].Value);
				int quantity = int.Parse(match.Groups["quantity"].Value);
				totalPrice += price * quantity;
				boughtItems.Add(match.Groups["item"].Value);
			}

			Console.WriteLine("Bought furniture:");
			if (boughtItems.Count > 0)
			{
				Console.WriteLine(string.Join("\n", boughtItems));
			}
			Console.WriteLine($"Total money spend: {totalPrice:F2}");

		}
	}
}
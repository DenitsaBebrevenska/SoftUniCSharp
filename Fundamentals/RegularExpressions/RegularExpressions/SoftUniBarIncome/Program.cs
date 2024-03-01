using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
	internal class Program
	{
		static void Main()
		{
			string input;
			decimal totalIncome = 0;

			while ((input = Console.ReadLine()) != "end of shift")
			{
				string customerName = GetToken(input,@"%(?<customer>[A-Z][a-z]+)%" );
				string product = GetToken(input,@"<(?<product>\w+)>");
				string quantity = GetToken(input, @"\|(?<quantity>\d+)\|");
				string price = GetToken(input,@"(?<price>\d+\.*\d*)\$");

				if (customerName == string.Empty || product == string.Empty ||
				    quantity == string.Empty || price == string.Empty)
				{
					continue;
				}

				int quantityNumber = int.Parse(quantity);
				decimal priceNumber = decimal.Parse(price);
				decimal totalClient = priceNumber * quantityNumber;
				totalIncome += totalClient;

				Console.WriteLine($"{customerName}: {product} - {totalClient:F2}");
			}

			Console.WriteLine($"Total income: {totalIncome:F2}");
		}

		private static string GetToken(string input, string filter)
		{
			Match match = Regex.Match(input, filter);

			return match.Groups[1].Value; //if there are no groups this will return {}, treat accordingly
		}
	}
}
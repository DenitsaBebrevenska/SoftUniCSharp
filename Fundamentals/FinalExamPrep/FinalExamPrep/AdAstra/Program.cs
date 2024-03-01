using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdAstra
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			string filterTokens = @"([|#])(?<item>[A-Za-z ]+)\1(?<expiration>\d{2}/\d{2}/\d{2})\1(?<calories>\d+)\1";
			int totalCalories = 0;
			List<Product> products = new List<Product>();
			MatchCollection matches = Regex.Matches(input, filterTokens);
			foreach (Match match in matches)
			{
				string productName = match.Groups["item"].Value;
				string expirationDate = match.Groups["expiration"].Value;
				int calories = int.Parse(match.Groups["calories"].Value);
				products.Add(new Product(productName, expirationDate,calories));
				totalCalories += calories;
			}

			int days = totalCalories / 2000; //daily intake 2000 kcal

			Console.WriteLine($"You have food to last you for: {days} days!");
			foreach (Product product in products)
			{
				Console.WriteLine($"Item: {product.Name}, Best before: {product.ExpirationDate}, Nutrition: {product.Calories}");
			}
		}
	}
}
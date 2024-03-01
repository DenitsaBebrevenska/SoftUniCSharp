namespace CaloriesCounter
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<string, int> ingredientsDictionary = new Dictionary<string, int>()
			{
				{"cheese", 500},
				{"tomato sauce", 150},
				{"salami", 600},
				{"pepper", 50}
			};

			int numberOfIngredients = int.Parse(Console.ReadLine());
			int totalCalories = 0;
			for (int i = 0; i < numberOfIngredients; i++)
			{
				string ingredient = Console.ReadLine();

				int caloriesIngredient = GetCalories(ingredientsDictionary, ingredient);
				totalCalories += caloriesIngredient;
			}

			Console.WriteLine($"Total calories: {totalCalories}");
		}

		static int GetCalories(Dictionary<string, int> ingredientsDictionary, string ingredient)
		{
			foreach (var kvp in ingredientsDictionary)
			{
				if (kvp.Key == ingredient.ToLower())
				{
					return kvp.Value;
				}
			}
			return 0;
		}
	}
}
namespace PizzaIngredients
{
	internal class Program
	{
		static void Main()
		{
			string[] ingredients = Console.ReadLine().Split();
			byte length = byte.Parse(Console.ReadLine());

			byte ingredientsCount = 0;
			List<string> usedIngredients = new List<string>();

			for (int i = 0; i < ingredients.Length; i++)
			{
				if (ingredients[i].Length == length)
				{
					ingredientsCount++;
					usedIngredients.Add(ingredients[i]);
					Console.WriteLine($"Adding {ingredients[i]}.");
				}

				if (usedIngredients.Count == 10)
				{
					break;
				}
			}

			Console.WriteLine($"Made pizza with total of {usedIngredients.Count} ingredients.");
			Console.WriteLine($"The ingredients are: {string.Join(", ", usedIngredients)}.");
		}
	}
}

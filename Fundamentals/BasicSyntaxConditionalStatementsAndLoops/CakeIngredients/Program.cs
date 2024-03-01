namespace CakeIngredients
{
	internal class Program
	{
		static void Main()
		{
			string input;
			int counter = 0;

			while ((input = Console.ReadLine()) != "Bake!")
			{
				string ingredient = input;
				Console.WriteLine($"Adding ingredient {ingredient}.");
				counter++;
			}

			Console.WriteLine($"Preparing cake with {counter} ingredients.");
		}
	}
}
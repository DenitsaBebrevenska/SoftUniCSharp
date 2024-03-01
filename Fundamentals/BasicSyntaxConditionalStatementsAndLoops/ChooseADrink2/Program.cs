namespace ChooseADrink2
{
	internal class Program
	{
		static void Main()
		{
			string profession = Console.ReadLine();
			int numberOfDrinks = int.Parse(Console.ReadLine());
			string drink = string.Empty;
			double priceTotal = 0;

			switch (profession)
			{
				case "Athlete":
					drink = "Water";
					priceTotal = 0.7 * numberOfDrinks;
					break;
				case "Businesswoman":
				case "Businessman":
					drink = "Coffee";
					priceTotal = 1 * numberOfDrinks;
					break;
				case "SoftUni Student":
					drink = "Beer";
					priceTotal = 1.7 * numberOfDrinks;
					break;
				default:
					drink = "Tea";
					priceTotal = 1.2 * numberOfDrinks;
					break;
			}

			Console.WriteLine($"The {profession} has to pay {priceTotal:F2}.");
		}
	}
}
namespace ChooseADrink
{
	internal class Program
	{
		static void Main()
		{
			string profession = Console.ReadLine();
			string drink = string.Empty;
			switch (profession)
			{
				case "Athlete":
					drink = "Water";
					break;
				case "Businesswoman":
				case "Businessman":
					drink = "Coffee";
					break;
				case "SoftUni Student":
					drink = "Beer";
					break;
				default:
					drink = "Tea";
					break;
			}

			Console.WriteLine(drink);
		}
	}
}
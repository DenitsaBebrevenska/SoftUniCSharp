namespace CharacterStats
{
	internal class Program
	{
		static void Main()
		{
			string name = Console.ReadLine();
			int currentHealth = int.Parse(Console.ReadLine());
			int maximumHealth = int.Parse(Console.ReadLine());
			int currentEnergy = int.Parse(Console.ReadLine());
			int maximumEnergy = int.Parse(Console.ReadLine());

			
			string healthBar = $"|{new string('|', currentHealth)}{new string('.', maximumHealth - currentHealth)}|";
			string energyBar = $"|{new string('|', currentEnergy)}{new string('.', maximumEnergy - currentEnergy)}|";

			Console.WriteLine($"Name: {name}");
			Console.WriteLine($"Health: {healthBar}");
			Console.WriteLine($"Energy: {energyBar}");
		}
	}
}
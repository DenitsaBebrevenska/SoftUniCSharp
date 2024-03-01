namespace NeighbourWars
{
	internal class Program
	{
		static void Main()
		{
			int peshoDamage = int.Parse(Console.ReadLine());
			int goshoDamage = int.Parse(Console.ReadLine());
			int peshoHp = 100, goshoHp = 100;

			int counter = 0;
			while (true)
			{
				string currentAttacker = "", currentDefender = "", currentSkill = "";
				int hpOfDefender = 0;
				counter++;

				if (counter % 2 != 0) //Pesho`s turn
				{
					goshoHp -= peshoDamage;
					hpOfDefender = goshoHp;
					currentAttacker = "Pesho";
					currentDefender = "Gosho";
					currentSkill = "Roundhouse kick";
				}
				else //Gosho`s turn
				{
					peshoHp -= goshoDamage;
					hpOfDefender = peshoHp;
					currentAttacker = "Gosho";
					currentDefender = "Pesho";
					currentSkill = "Thunderous fist";
				}

				if (goshoHp <= 0 || peshoHp <= 0)
				{
					Console.WriteLine($"{currentAttacker} won in {counter}th round.");
					break;
				}

				Console.WriteLine($"{currentAttacker} used {currentSkill} and reduced " +
					$"{currentDefender} to {hpOfDefender} health.");

				if (counter % 3 == 0)
				{
					goshoHp += 10;
					peshoHp += 10;
				}
			}
		}
	}
}
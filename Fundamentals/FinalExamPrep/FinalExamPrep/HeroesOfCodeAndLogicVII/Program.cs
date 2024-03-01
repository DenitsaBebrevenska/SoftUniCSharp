namespace HeroesOfCodeAndLogicVII
{
	internal class Program
	{
		static void Main()
		{
			int numberOfHeroes = int.Parse(Console.ReadLine());
			List<Hero> heroes = SetParty(numberOfHeroes);
			string input;

			while ((input = Console.ReadLine()) != "End")
			{
				string[] actionDetails = input.Split(" - ");
				string heroName = actionDetails[1];
				Hero hero = heroes.FirstOrDefault(x => x.Name == heroName);

				switch (actionDetails[0])
				{
					case "CastSpell":
						CastSpell(actionDetails, hero);
						break;
					case "TakeDamage":
						TakeDamage(actionDetails, hero, heroes);
						break;
					case "Recharge":
						RechargeMana(actionDetails, hero);
						break;
					case "Heal":
						HealHero(actionDetails, hero);
						break;
				}
			}

			Console.WriteLine(string.Join("\n", heroes));
		}

		static List<Hero> SetParty(int numberOfHeroes)
		{
			List<Hero> heroes = new List<Hero>();
			for (int i = 0; i < numberOfHeroes; i++)
			{
				string[] heroDetails = Console.ReadLine().Split();
				heroes.Add(new Hero(heroDetails[0], int.Parse(heroDetails[1]), int.Parse(heroDetails[2])));
			}
			return heroes;
		}

		static void CastSpell(string[] actionDetails, Hero hero)
		{
			int neededMana = int.Parse(actionDetails[2]);
			string spell = actionDetails[3];
			if (neededMana > hero.ManaPoints)
			{
				Console.WriteLine($"{hero.Name} does not have enough MP to cast {spell}!");
				return;
			}

			hero.ManaPoints -= neededMana;
			Console.WriteLine($"{hero.Name} has successfully cast {spell} and now has {hero.ManaPoints} MP!");
		}

		static void TakeDamage(string[] actionDetails, Hero hero, List<Hero> heroes)
		{
			int damage = int.Parse(actionDetails[2]);
			string attacker = actionDetails[3];
			hero.HitPoints -= damage;
			if (hero.HitPoints <= 0)
			{
				Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
				heroes.Remove(hero);
				return;
			}

			Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.HitPoints} HP left!");
		}

		static void RechargeMana(string[] actionDetails, Hero hero)
		{
			int rechargedMana = int.Parse(actionDetails[2]);
			if (rechargedMana + hero.ManaPoints > 200)
			{
				rechargedMana = 200 - hero.ManaPoints;
			}
			hero.ManaPoints += rechargedMana;
			Console.WriteLine($"{hero.Name} recharged for {rechargedMana} MP!");
		}

		static void HealHero(string[] actionDetails, Hero hero)
		{
			int healedHp = int.Parse(actionDetails[2]);
			if (healedHp + hero.HitPoints > 100)
			{
				healedHp = 100 - hero.HitPoints;
			}
			hero.HitPoints += healedHp;
			Console.WriteLine($"{hero.Name} healed for {healedHp} HP!");
		}
	}
}
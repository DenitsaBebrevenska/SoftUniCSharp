using System.Text.RegularExpressions;

namespace NetherRealms
{
	internal class Program
	{
		static void Main()
		{
			string[] demons = Console.ReadLine().
				Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).
				ToArray();
			string filterHealth = @"[^\+\-*\/0-9\.]";
			string filterDamage = @"[-|+]?\d+\.?\d*";
			string filterBonusDamage = @"[/*]";
			List<Demon> demonBook = new List<Demon>();

			for (int i = 0; i < demons.Length; i++)
			{
				MatchCollection matches = Regex.Matches(demons[i], filterHealth);
				int health = matches.Sum(x => x.Value[0]);
				
				matches = Regex.Matches(demons[i], filterDamage);
				double damage = matches.Sum(x => double.Parse(x.Value));
				
				matches = Regex.Matches(demons[i], filterBonusDamage);

				foreach (Match match in matches)
				{
					if (match.Value == "/")
					{
						damage /= 2;
					}
					else
					{
						damage *= 2;
					}
				}

				demonBook.Add(new Demon(demons[i], health, damage));
			}

			foreach (Demon demon in demonBook.OrderBy(x => x.Name))
			{
				Console.WriteLine($"{demon.Name} - {demon.HealthPoints} health, {demon.Damage:F2} damage");
			}
		}
	}
}
using Raiding.Factory;
using Raiding.Models;

namespace Raiding.Core
{
    public class Engine
    {
        public void Run()
        {
            int partyFreeSpots = int.Parse(Console.ReadLine());
            List<BaseHero> party = new List<BaseHero>();
            HeroFactory heroFactory = new HeroFactory();

            while (partyFreeSpots > 0)
            {
                try
                {
                    string heroName = Console.ReadLine();
                    string heroType = Console.ReadLine();
                    var hero = heroFactory.CreateHero(heroName, heroType);
                    party.Add(hero);
                    partyFreeSpots--;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            int bossPower = int.Parse(Console.ReadLine());
            party.ForEach(h => Console.WriteLine(h.CastAbility()));
            int partyPower = party.Sum(h => h.Power);

            Console.WriteLine(partyPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}

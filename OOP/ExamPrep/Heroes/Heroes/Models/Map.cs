using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<Knight> knights = players.Where(p => p.GetType().Name == "Knight").Cast<Knight>().ToList();
            List<Barbarian> barbarians = players.Where(p => p.GetType().Name == "Barbarian").Cast<Barbarian>().ToList();

            while (TeamHasSurvivors(knights) && TeamHasSurvivors(barbarians))
            {
                foreach (var knight in knights.Where(k => k.IsAlive))
                {
                    foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                {
                    foreach (var knight in knights.Where(k => k.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }
            }

            if (TeamHasSurvivors(knights))
            {
                return string.Format(OutputMessages.MapFightKnightsWin, knights.Count(k => !k.IsAlive));
            }

            //since there is no option for equality and there is always a survivor in just one of the teams

            return string.Format(OutputMessages.MapFigthBarbariansWin, barbarians.Count(b => !b.IsAlive));
        }

        private bool TeamHasSurvivors<T>(List<T> heroes)
            => heroes.Cast<IHero>().Any(h => h.IsAlive);

    }
}

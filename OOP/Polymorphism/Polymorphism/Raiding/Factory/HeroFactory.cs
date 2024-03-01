using Raiding.Models;

namespace Raiding.Factory
{
    public class HeroFactory
    {
        public BaseHero CreateHero(string name, string type)
        {
            if (type == "Druid")
            {
                return new Druid(name);
            }
            else if (type == "Paladin")
            {
                return new Paladin(name);
            }
            else if (type == "Rogue")
            {
                return new Rogue(name);
            }
            else if (type == "Warrior")
            {
                return new Warrior(name);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }
        }
    }
}

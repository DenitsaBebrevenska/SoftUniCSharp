namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int Power = 80;

        public override string CastAbility() => base.CastAbility() + $"healed for {Power}";

        public Druid(string name) : base(name, Power)
        {
        }
    }
}

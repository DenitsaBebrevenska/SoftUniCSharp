namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public const int Power = 80;
        public Rogue(string name) : base(name, Power)
        {
        }
        public override string CastAbility() => base.CastAbility() + $"hit for {Power} damage";
    }
}

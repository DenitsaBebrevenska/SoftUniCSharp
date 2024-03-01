namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public const int Power = 100;
        public Warrior(string name) : base(name, Power)
        {
        }
        public override string CastAbility() => base.CastAbility() + $"hit for {Power} damage";
    }
}

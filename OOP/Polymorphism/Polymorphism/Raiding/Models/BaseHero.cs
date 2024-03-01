namespace Raiding.Models
{
    public abstract class BaseHero
    {
        public int Power { get; private set; }
        public string Name { get; private set; }

        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public virtual string CastAbility() => $"{GetType().Name} - {Name} ";
    }
}

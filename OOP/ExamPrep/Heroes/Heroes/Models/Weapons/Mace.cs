namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int MaceDamage = 25;
        public Mace(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            base.DoDamage();

            return Durability == 0 ? 0 : MaceDamage;
        }
    }
}

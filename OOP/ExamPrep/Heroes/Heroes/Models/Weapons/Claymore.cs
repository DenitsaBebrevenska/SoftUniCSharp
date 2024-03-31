namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int ClaymoreDamage = 20;
        public Claymore(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            base.DoDamage();

            return Durability == 0 ? 0 : ClaymoreDamage;
        }
    }
}

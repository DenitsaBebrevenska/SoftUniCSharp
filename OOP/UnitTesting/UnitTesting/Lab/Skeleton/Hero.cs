namespace Skeleton
{
    public class Hero
    {
        private string name;
        private int experience;
        private IWeapon weapon;

        public Hero(string name, IWeapon weapon)
        {
            this.name = name;
            experience = 0;
            this.weapon = weapon;
        }

        public int Experience => experience;
        public void Attack(ITarget target)
        {
            weapon.Attack(target);

            if (target.IsDead())
            {
                experience += target.GiveExperience();
            }
        }
    }
}

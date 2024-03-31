using Heroes.Core;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Weapons;

namespace Heroes
{
    public class StartUp
    {
        public static void Main()
        {
            IWeapon weapon = new Mace("Mace", 20);
            weapon.DoDamage();

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;
        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => models.AsReadOnly();
        public void AddItem(IWeapon model)
            => models.Add(model);

        public IWeapon FindByName(string name)
            => models.FirstOrDefault(w => w.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IWeapon weapon = FindByName(name);

            if (weapon != null)
            {
                models.Remove(weapon);
                return true;
            }

            return false;
        }
    }
}

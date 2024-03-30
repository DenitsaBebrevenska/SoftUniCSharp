using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;
        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => models.AsReadOnly();
        public void AddItem(IMilitaryUnit model)
            => models.Add(model);

        public IMilitaryUnit FindByName(string name)
            => models.FirstOrDefault(mu => mu.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IMilitaryUnit militaryUnit = FindByName(name);

            if (militaryUnit != null)
            {
                models.Remove(militaryUnit);
                return true;
            }

            return false;
        }
    }
}

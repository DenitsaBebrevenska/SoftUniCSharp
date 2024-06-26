﻿using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;
        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();
        public void Add(IWeapon model)
            => weapons.Add(model);

        public bool Remove(IWeapon model)
            => weapons.Remove(model);

        public IWeapon FindByName(string name)
            => weapons.FirstOrDefault(w => w.Name == name);
    }
}

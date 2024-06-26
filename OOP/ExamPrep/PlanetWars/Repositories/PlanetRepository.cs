﻿using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;
        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();
        public void AddItem(IPlanet model)
            => models.Add(model);

        public IPlanet FindByName(string name)
            => models.FirstOrDefault(p => p.Name == name);

        public bool RemoveItem(string name)
        {
            IPlanet planet = FindByName(name);

            if (planet != null)
            {
                models.Remove(planet);
                return true;
            }

            return false;
        }
    }
}

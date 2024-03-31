using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;
        public HeroRepository()
        {
            heroes = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => heroes.AsReadOnly();
        public void Add(IHero model)
            => heroes.Add(model);

        public bool Remove(IHero model)
            => heroes.Remove(model);

        public IHero FindByName(string name)
            => heroes.FirstOrDefault(h => h.Name == name);
    }
}

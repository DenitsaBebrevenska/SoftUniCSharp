using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> _models;

        public TeamRepository()
        {
            _models = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => _models.AsReadOnly();
        public void AddModel(ITeam model)
         => _models.Add(model);

        public bool RemoveModel(string name)
        {
            ITeam teamToRemove = _models.FirstOrDefault(m => m.Name == name);

            if (teamToRemove != null)
            {
                _models.Remove(teamToRemove);
                return true;
            }

            return false;
        }

        public bool ExistsModel(string name)
            => _models.Any(m => m.Name == name);

        public ITeam GetModel(string name)
            => _models.FirstOrDefault(m => m.Name == name);
    }
}

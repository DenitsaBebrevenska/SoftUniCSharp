using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> _models;

        public PlayerRepository()
        {
            _models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => _models.AsReadOnly();

        public void AddModel(IPlayer model)
            => _models.Add(model);

        public bool RemoveModel(string name)
        {
            IPlayer playerToRemove = _models.FirstOrDefault(m => m.Name == name);

            if (playerToRemove != null)
            {
                _models.Remove(playerToRemove);
                return true;
            }

            return false;
        }

        public bool ExistsModel(string name)
            => _models.Any(m => m.Name == name);

        public IPlayer GetModel(string name)
            => _models.FirstOrDefault(m => m.Name == name);
    }
}

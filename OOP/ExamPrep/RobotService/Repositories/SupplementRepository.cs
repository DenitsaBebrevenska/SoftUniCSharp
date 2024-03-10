using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> _models;

        public SupplementRepository()
        {
            _models = new List<ISupplement>();
        }

        public IReadOnlyCollection<ISupplement> Models()
            => _models.AsReadOnly();

        public void AddNew(ISupplement model)
             => _models.Add(model);

        public bool RemoveByName(string typeName)
            => _models.Remove(_models.FirstOrDefault(m => m.GetType().Name == typeName));

        public ISupplement FindByStandard(int interfaceStandard)
            => _models.FirstOrDefault(m => m.InterfaceStandard == interfaceStandard);
    }
}

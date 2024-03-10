using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> _models;
        public IReadOnlyCollection<IRobot> Models() => _models.AsReadOnly();

        public void AddNew(IRobot model)
            => _models.Add(model);

        public bool RemoveByName(string typeName)
            => _models.Remove(_models.FirstOrDefault(m => m.GetType().Name == typeName));

        public IRobot FindByStandard(int interfaceStandard)
            => _models.FirstOrDefault(m => m.InterfaceStandards.Contains(interfaceStandard));
    }
}

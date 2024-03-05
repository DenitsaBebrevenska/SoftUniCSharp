using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> _models;
        public IReadOnlyCollection<IBank> Models => _models.AsReadOnly();

        public BankRepository()
        {
            _models = new List<IBank>();
        }
        public void AddModel(IBank model)
            => _models.Add(model);

        public bool RemoveModel(IBank model)
            => _models.Remove(model);

        public IBank FirstModel(string name)
            => _models.FirstOrDefault(m => m.Name == name);
    }
}

using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> _models;
        public IReadOnlyCollection<ILoan> Models => _models.AsReadOnly();

        public LoanRepository()
        {
            _models = new List<ILoan>();
        }
        public void AddModel(ILoan model)
            => _models.Add(model);

        public bool RemoveModel(ILoan model)
            => _models.Remove(model);

        public ILoan FirstModel(string name)
            => _models.FirstOrDefault(m => m.GetType().Name == name);
    }
}

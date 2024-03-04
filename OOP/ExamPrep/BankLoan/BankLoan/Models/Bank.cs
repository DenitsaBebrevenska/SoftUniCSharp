using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        public string Name { get; }
        public int Capacity { get; }
        public IReadOnlyCollection<ILoan> Loans { get; }
        public IReadOnlyCollection<IClient> Clients { get; }
        public double SumRates()
        {
            throw new NotImplementedException();
        }

        public void AddClient(IClient Client)
        {
            throw new NotImplementedException();
        }

        public void RemoveClient(IClient Client)
        {
            throw new NotImplementedException();
        }

        public void AddLoan(ILoan loan)
        {
            throw new NotImplementedException();
        }

        public string GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}

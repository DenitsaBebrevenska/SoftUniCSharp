using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankLoan.Models.Banks
{
    public abstract class Bank : IBank
    {
        private string _name;
        private List<ILoan> _loans;
        private List<IClient> _clients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _loans = new List<ILoan>();
            _clients = new List<IClient>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                _name = value;
            }
        }
        public int Capacity { get; private set; }
        public IReadOnlyCollection<ILoan> Loans => _loans.AsReadOnly();
        public IReadOnlyCollection<IClient> Clients => _clients.AsReadOnly();

        public double SumRates()
            => _loans.Sum(l => l.InterestRate);

        public void AddClient(IClient client)
        {
            if (Capacity == _clients.Count)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }

            _clients.Add(client);
        }

        public void RemoveClient(IClient client)
         => _clients.Remove(client);

        public void AddLoan(ILoan loan)
            => _loans.Add(loan);

        public string GetStatistics()
        {
            StringBuilder statistics = new StringBuilder();
            statistics.AppendLine($"Name: {Name}, Type: {GetType().Name}");
            string clients = _clients.Count == 0 ? "none" : $"{string.Join(", ", _clients.Select(c => c.Name))}";
            statistics.AppendLine($"Clients: {clients}");
            statistics.AppendLine($"Loans: {_loans.Count}, Sum of Rates: {SumRates()}");

            return statistics.ToString().TrimEnd();
        }
    }
}

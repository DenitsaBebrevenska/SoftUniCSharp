using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;

namespace BankLoan.Models.Clients
{
    public abstract class Client : IClient
    {
        private string _name;
        private string _id;
        private double _income;

        protected Client(string name, string id, int interest, double income)
        {
            Name = name;
            Id = id;
            Interest = interest;
            Income = income;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClientNameNullOrWhitespace);
                }
                _name = value;
            }
        }

        public string Id
        {
            get => _id;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClientIdNullOrWhitespace);
                }
                _id = value;
            }
        }
        public int Interest { get; protected set; }

        public double Income
        {
            get => _income;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.ClientIncomeBelowZero);
                }
                _income = value;
            }
        }

        public abstract void IncreaseInterest();
    }
}

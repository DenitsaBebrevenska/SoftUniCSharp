using Chainblock.Contracts;
using Chainblock.Enums;
using Chainblock.Exceptions;
using System;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id
        {
            get => id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(TransactionExceptions.IdMustBePositive);
                }
                id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get => from;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(TransactionExceptions.SenderMustNotBeNullOrWhiteSpace);
                }
                from = value;
            }
        }
        public string To
        {
            get => to;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(TransactionExceptions.ReceiverMustNotBeNullOrWhiteSpace);
                }
                to = value;
            }
        }

        public double Amount
        {
            get => amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(TransactionExceptions.AmountMustBePositive);
                }
                amount = value;
            }
        }
    }
}

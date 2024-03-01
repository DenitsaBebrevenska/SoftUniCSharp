using Chainblock.Contracts;
using Chainblock.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using TransactionStatus = Chainblock.Enums.TransactionStatus;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private Dictionary<int, ITransaction> transactions;

        public Chainblock()
        {
            transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => transactions.Count;
        public void Add(ITransaction tx)
        {
            if (transactions.All(t => t.Key != tx.Id))
            {
                transactions.Add(tx.Id, tx);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ChainblockExceptions.TransactionCannotBeAdded, tx.Id));
            }
        }

        public bool Contains(int id)
        => transactions.ContainsKey(id);

        public bool Contains(ITransaction tx)
            => Contains(tx.Id);

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction tx = transactions.FirstOrDefault(t => t.Key == id).Value;

            if (tx is null)
            {
                throw new ArgumentException(string.Format(ChainblockExceptions.TransactionDoesNotExist, id));
            }

            tx.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            ITransaction tx = transactions.FirstOrDefault(t => t.Key == id).Value;

            if (tx is null)
            {
                throw new InvalidOperationException(string.Format(ChainblockExceptions.TransactionDoesNotExist, id));
            }

            transactions.Remove(tx.Id);
        }

        public ITransaction GetById(int id)
        {
            ITransaction tx = transactions.FirstOrDefault(t => t.Key == id).Value;

            if (tx is null)
            {
                throw new InvalidOperationException(string.Format(ChainblockExceptions.TransactionDoesNotExist, id));
            }

            return tx;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (transactions.All(t => t.Value.Status != status))
            {
                throw new InvalidOperationException(
                    string.Format(ChainblockExceptions.NoTransactionsWithSuchStatusFound, status.ToString()));
            }

            return transactions.Values
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount);
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (transactions.All(t => t.Value.Status != status))
            {
                throw new InvalidOperationException(
                    string.Format(ChainblockExceptions.NoTransactionsWithSuchStatusFound, status.ToString()));
            }

            return transactions.Values.Where(t => t.Status == status)
                .OrderBy(t => t.Amount).Select(t => t.From);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (transactions.All(t => t.Value.Status != status))
            {
                throw new InvalidOperationException(
                    string.Format(ChainblockExceptions.NoTransactionsWithSuchStatusFound, status.ToString()));
            }

            return transactions.Values.Where(t => t.Status == status)
                .OrderBy(t => t.Amount).Select(t => t.To);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
            => transactions.Values.OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (transactions.All(t => t.Value.From != sender))
            {
                throw new InvalidOperationException(
                    string.Format(ChainblockExceptions.NoTransactionsWithSuchSenderFound, sender));
            }

            return transactions.Values
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount);
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if (transactions.All(t => t.Value.To != receiver))
            {
                throw new InvalidOperationException(
                    string.Format(ChainblockExceptions.NoTransactionsWithSuchReceiverFound, receiver));
            }

            return transactions.Values
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        => transactions.Values.Where(t => t.Status == status && t.Amount <= amount)
            .OrderByDescending(t => t.Amount);

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            if (transactions.All(t => t.Value.From != sender || t.Value.Amount <= amount))
            {
                throw new InvalidOperationException(
                    string.Format(ChainblockExceptions.NoTransactionsWithSuchSenderAndMinAmount, sender, amount));
            }

            return transactions.Values.Where(t => t.From == sender && t.Amount > amount)
                .OrderByDescending(t => t.Amount);
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            if (transactions.All(t => t.Value.To != receiver || (t.Value.Amount < lo || t.Value.Amount >= hi)))
            {
                throw new InvalidOperationException(
                    string.Format(ChainblockExceptions.NoTransactionsWithSuchReceiverAndAmountRangeFound, receiver, lo, hi));
            }

            return transactions.Values.Where(t => t.To == receiver & t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
            => transactions.Values.Where(t => t.Amount >= lo && t.Amount <= hi);
    }
}

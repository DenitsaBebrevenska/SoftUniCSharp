using Chainblock.Contracts;
using Chainblock.Enums;
using Chainblock.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private ITransaction transaction;
        private ITransaction transaction2;
        private ITransaction transaction3;
        private IChainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            transaction = new Transaction(1, TransactionStatus.Successfull, "Daniel", "Cibila", 202.20);
            transaction2 = new Transaction(2, TransactionStatus.Unauthorised, "KFC", "AMD", 20_000_00.50);
            transaction3 = new Transaction(3, TransactionStatus.Failed, "Zack", "Bella", 50);
            chainblock = new Chainblock();
        }

        [Test]
        public void Constructor_ShouldInitialize()
        {
            Assert.IsNotNull(chainblock);
        }

        [Test]
        public void Count_ShouldCorrectlyReturnCountOfCollection()
        {
            Assert.AreEqual(0, chainblock.Count);
            chainblock.Add(transaction);
            Assert.AreEqual(1, chainblock.Count);
            chainblock.Add(transaction2);
            Assert.AreEqual(2, chainblock.Count);
        }


        [Test]
        public void Add_ShouldAddToTheCollection()
        {
            Assert.AreEqual(0, chainblock.Count);
            Assert.IsFalse(chainblock.Contains(transaction.Id));
            Assert.IsFalse(chainblock.Contains(transaction));
            chainblock.Add(transaction);
            Assert.IsTrue(chainblock.Contains(transaction.Id));
            Assert.IsTrue(chainblock.Contains(transaction));
        }

        [Test]
        public void Add_ShouldCorrectlyIncreaseCount()
        {
            Assert.AreEqual(0, chainblock.Count);
            chainblock.Add(transaction);
            Assert.AreEqual(1, chainblock.Count);
            chainblock.Add(transaction3);
            Assert.AreEqual(2, chainblock.Count);
        }

        [Test]
        public void Add_ShouldThrowAnException_WhenTransactionAlreadyExists()
        {
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainblock.Add(transaction3));

            Assert.AreEqual(string.Format(ChainblockExceptions.TransactionCannotBeAdded, transaction3.Id), exception.Message);
        }

        [Test]
        public void ContainsById_ShouldCorrectlyReturn()
        {
            Assert.IsFalse(chainblock.Contains(transaction.Id));
            chainblock.Add(transaction);
            Assert.IsTrue(chainblock.Contains(transaction.Id));
        }

        [Test]
        public void ContainsByTransaction_ShouldCorrectlyReturn()
        {
            Assert.IsFalse(chainblock.Contains(transaction));
            chainblock.Add(transaction);
            Assert.IsTrue(chainblock.Contains(transaction));
        }

        [TestCase(TransactionStatus.Unauthorised)]
        [TestCase(TransactionStatus.Failed)]
        public void ChangeTransactionStatus_ShouldCorrectlyChangeStatus(TransactionStatus ts)
        {
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(transaction.Id, ts);
            Assert.AreEqual(ts, chainblock.GetById(transaction.Id).Status);
        }


        [TestCase(1000)]
        [TestCase(20)]
        public void ChangeTransactionStatus_ShouldThrowException_IfNoTransactionWithThatIdIsFound(int missingId)
        {
            chainblock.Add(transaction3);
            chainblock.Add(transaction2);

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => chainblock.ChangeTransactionStatus(missingId, TransactionStatus.Successfull));

            Assert.AreEqual(string.Format(ChainblockExceptions.TransactionDoesNotExist, missingId), exception.Message);
        }

        [Test]
        public void RemoveTransactionById_ShouldCorrectlyRemove()
        {
            chainblock.Add(transaction);
            Assert.IsTrue(chainblock.Contains(transaction));
            chainblock.RemoveTransactionById(transaction.Id);
            Assert.IsFalse(chainblock.Contains(transaction));
        }


        [TestCase(1000)]
        [TestCase(20)]
        public void RemoveTransactionById_ShouldThrowException_IfNoTransactionWithThatIdIsFound(int missingId)
        {
            chainblock.Add(transaction3);
            chainblock.Add(transaction2);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainblock.RemoveTransactionById(missingId));

            Assert.AreEqual(string.Format(ChainblockExceptions.TransactionDoesNotExist, missingId), exception.Message);
        }

        [Test]
        public void GetBy_ShouldCorrectlyReturn()
        {
            chainblock.Add(transaction3);
            Assert.AreEqual(transaction3, chainblock.GetById(transaction3.Id));
            chainblock.Add(transaction2);
            Assert.AreEqual(transaction2, chainblock.GetById(transaction2.Id));
        }

        [TestCase(1000)]
        [TestCase(20)]
        public void GetBy_ShouldThrowException_IfNoTransactionWithThatIdIsFound(int missingId)
        {
            chainblock.Add(transaction);
            chainblock.Add(transaction2);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainblock.GetById(missingId));

            Assert.AreEqual(string.Format(ChainblockExceptions.TransactionDoesNotExist, missingId), exception.Message);
        }

        [Test]
        public void GetByTransactionStatus_ShouldCorrectlyReturn()
        {
            transaction3.Status = TransactionStatus.Successfull;
            transaction2.Status = TransactionStatus.Successfull;
            chainblock.Add(transaction3);
            chainblock.Add(transaction2);
            chainblock.Add(transaction);

            IEnumerable<ITransaction> expectedResult = new List<ITransaction>()
            {
                transaction2,
                transaction,
                transaction3
            };


            IEnumerable<ITransaction> statusSuccessfullTransactions =
                chainblock.GetByTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedResult, statusSuccessfullTransactions);
        }

        [Test]
        public void GetByTransactionStatus_ShouldThrowException_WhenNoTransactionsWithThatStatusAreFound()
        {
            chainblock.Add(transaction);
            chainblock.Add(transaction2);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainblock.GetByTransactionStatus(TransactionStatus.Aborted));

            Assert.AreEqual(string.Format(ChainblockExceptions.NoTransactionsWithSuchStatusFound, TransactionStatus.Aborted), exception.Message);
        }

        [Test]
        public void GetAllSendersByTransactionStatus_ShouldWorkCorrectly()
        {
            transaction3.Status = TransactionStatus.Successfull;
            transaction2.Status = TransactionStatus.Successfull;
            chainblock.Add(transaction3);
            chainblock.Add(transaction2);
            chainblock.Add(transaction);

            IEnumerable<string> expectedResult = new List<string>()
            {
                transaction3.From,
                transaction.From,
                transaction2.From
            };


            IEnumerable<string> senderTransactions =
                chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedResult, senderTransactions);
        }

        [Test]
        public void GetAllSendersByTransactionStatus_ShouldThrowException_WhenNoTransactionsWithThatStatusAreFound()
        {
            chainblock.Add(transaction);
            chainblock.Add(transaction2);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainblock.GetByTransactionStatus(TransactionStatus.Aborted));

            Assert.AreEqual(string.Format(ChainblockExceptions.NoTransactionsWithSuchStatusFound, TransactionStatus.Aborted), exception.Message);
        }

        [Test]
        public void GetAllReceiversByTransactionStatus_ShouldWorkCorrectly()
        {
            transaction3.Status = TransactionStatus.Successfull;
            transaction2.Status = TransactionStatus.Successfull;
            chainblock.Add(transaction3);
            chainblock.Add(transaction2);
            chainblock.Add(transaction);

            IEnumerable<string> expectedResult = new List<string>()
            {
                transaction3.To,
                transaction.To,
                transaction2.To
            };

            IEnumerable<string> receiverTransactions =
            chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedResult, receiverTransactions);
        }

        [Test]
        public void GetAllReceiversByTransactionStatus_ShouldThrowException_WhenNoTransactionsWithThatStatusAreFound()
        {
            chainblock.Add(transaction);
            chainblock.Add(transaction2);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainblock.GetByTransactionStatus(TransactionStatus.Aborted));

            Assert.AreEqual(string.Format(ChainblockExceptions.NoTransactionsWithSuchStatusFound, TransactionStatus.Aborted), exception.Message);
        }

        [Test]
        public void GetAllByAmountDescendingThenById_ShouldWorkCorrectly()
        {
            chainblock.Add(transaction3);
            chainblock.Add(transaction2);
            chainblock.Add(transaction);

            IEnumerable<ITransaction> expectedResult = new List<ITransaction>()
            {
                transaction3,
                transaction,
                transaction2
            };

            expectedResult = expectedResult.OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            IEnumerable<ITransaction> result =
                chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldThrowException_WhenNoTransactionsWithThatSenderAreFound()
        {
            string missingSender = "Ivan";
            chainblock.Add(transaction);
            chainblock.Add(transaction2);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainblock.GetBySenderOrderedByAmountDescending(missingSender));

            Assert.AreEqual(string.Format(ChainblockExceptions.NoTransactionsWithSuchSenderFound, missingSender), exception.Message);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldWorkCorrectly()
        {
            string newSender = "Zack";
            transaction.From = newSender;
            transaction2.From = newSender;
            chainblock.Add(transaction3);
            chainblock.Add(transaction2);
            chainblock.Add(transaction);

            IEnumerable<ITransaction> expectedResult = new List<ITransaction>()
            {
                transaction3,
                transaction,
                transaction2
            };

            expectedResult = expectedResult.OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> sendersOrdered =
                chainblock.GetBySenderOrderedByAmountDescending(newSender);

            CollectionAssert.AreEqual(expectedResult, sendersOrdered);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldWorkCorrectly()
        {
            string newReceiver = "Bella";
            transaction.To = newReceiver;
            transaction2.To = newReceiver;
            chainblock.Add(transaction3);
            chainblock.Add(transaction2);
            chainblock.Add(transaction);

            IEnumerable<ITransaction> expectedResult = new List<ITransaction>()
            {
                transaction3,
                transaction,
                transaction2
            };

            expectedResult = expectedResult.OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            IEnumerable<ITransaction> receiverTransactions =
                chainblock.GetByReceiverOrderedByAmountThenById(newReceiver);

            CollectionAssert.AreEqual(expectedResult, receiverTransactions);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldThrowException_WhenNoTransactionsWithThatReceiverAreFound()
        {
            string missingReceiver = "Ivan";
            chainblock.Add(transaction);
            chainblock.Add(transaction2);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainblock.GetByReceiverOrderedByAmountThenById(missingReceiver));

            Assert.AreEqual(string.Format(ChainblockExceptions.NoTransactionsWithSuchReceiverFound, missingReceiver), exception.Message);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldWorkCorrectly()
        {
            transaction3.Status = TransactionStatus.Successfull;
            transaction2.Status = TransactionStatus.Successfull;
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            IEnumerable<ITransaction> expectedResult = new List<ITransaction>()
            {
                transaction,
                transaction3
            };

            expectedResult = expectedResult.OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> result =
                chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 300);

            CollectionAssert.AreEqual(expectedResult, result);
        }


        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnEmptyCollection_WhenNoTransactionsFoundByCriteria()
        {
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            IEnumerable<ITransaction> expectedResult = Enumerable.Empty<ITransaction>();
            IEnumerable<ITransaction> result =
                chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 20);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldWorkCorrectly()
        {
            string newSender = "Zack";
            transaction.From = newSender;
            transaction2.From = newSender;
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            IEnumerable<ITransaction> expectedResult = new List<ITransaction>()
            {
                transaction,
                transaction2
            };

            expectedResult = expectedResult.OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> sendersOrdered =
                chainblock.GetBySenderAndMinimumAmountDescending(newSender, 50);

            CollectionAssert.AreEqual(expectedResult, sendersOrdered);
        }


        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrowException_WhenNoTransactionAreFoundByCriteria()
        {
            string sender = "Zack";
            int amount = 100;
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainblock.GetBySenderAndMinimumAmountDescending(sender, amount));

            Assert.AreEqual(string.Format(ChainblockExceptions.NoTransactionsWithSuchSenderAndMinAmount, sender, amount), exception.Message);
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldWorkCorrectly()
        {
            string newReceiver = "Bella";
            transaction.To = newReceiver;
            transaction2.To = newReceiver;
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            IEnumerable<ITransaction> expectedResult = new List<ITransaction>()
            {
                transaction,
                transaction3
            };

            expectedResult = expectedResult.OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            IEnumerable<ITransaction> result =
                chainblock.GetByReceiverAndAmountRange(newReceiver, 10, 500);

            CollectionAssert.AreEqual(expectedResult, result);
        }


        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrowException_WhenNoTransactionAreFoundByCriteria()
        {
            string receiver = "AMD";
            double lo = 10;
            double hi = 500;
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => chainblock.GetByReceiverAndAmountRange(receiver, lo, hi));

            Assert.AreEqual(string.Format(ChainblockExceptions.NoTransactionsWithSuchReceiverAndAmountRangeFound, receiver, lo, hi), exception.Message);
        }

        [Test]
        public void GetAllInAmountRange_ShouldWorkCorrectly()
        {
            double lo = 20;
            double hi = 500;
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            IEnumerable<ITransaction> expectedResult = new List<ITransaction>()
            {
                transaction,
                transaction3
            };

            IEnumerable<ITransaction> result =
                chainblock.GetAllInAmountRange(lo, hi);

            CollectionAssert.AreEqual(expectedResult, result);
        }


        [Test]
        public void GetAllInAmountRange_ShouldReturnEmptyCollection_WhenNoTransactionsFoundByCriteria()
        {
            double lo = 0;
            double hi = 40;
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            IEnumerable<ITransaction> expectedResult = Enumerable.Empty<ITransaction>();
            IEnumerable<ITransaction> result =
                chainblock.GetAllInAmountRange(lo, hi);

            CollectionAssert.AreEqual(expectedResult, result);
        }

    }
}
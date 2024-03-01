using Chainblock.Contracts;
using Chainblock.Enums;
using Chainblock.Exceptions;
using NUnit.Framework;
using System;

namespace Chainblock.Tests
{
    public class TransactionTests
    {
        private ITransaction transaction;
        private int expectedId = 1;
        private TransactionStatus expectedStatus = TransactionStatus.Successfull;
        private string expectedSender = "Aleks";
        private string expectedReceiver = "Daniel";
        private double expectedAmount = 500.05;

        [SetUp]
        public void SetUp()
        {
            transaction = new Transaction(expectedId, expectedStatus, expectedSender, expectedReceiver, expectedAmount);
        }

        [Test]
        public void Constructor_ShouldInitialize()
        {
            Assert.IsNotNull(transaction);
        }

        [Test]
        public void Id_ShouldCorrectlyBeSet()
        {
            Assert.AreEqual(expectedId, transaction.Id);
        }

        [Test]
        public void Id_ShouldThrowException_WhenGivenNegativeNumber()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    new Transaction(-1, expectedStatus, expectedSender, expectedReceiver, expectedAmount);
                });

            Assert.AreEqual(TransactionExceptions.IdMustBePositive, exception.Message);
        }

        [Test]
        public void Status_ShouldCorrectlyBeSet()
        {
            Assert.AreEqual(expectedStatus, transaction.Status);
        }


        [Test]
        public void From_ShouldCorrectlyBeSet()
        {
            Assert.AreEqual(expectedSender, transaction.From);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("\t")]
        [TestCase("\u3000")]
        public void From_ShouldThrowException_WhenGivenNullOrWhiteSpace(string invalidSender)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    new Transaction(expectedId, expectedStatus, invalidSender, expectedReceiver, expectedAmount);
                });

            Assert.AreEqual(TransactionExceptions.SenderMustNotBeNullOrWhiteSpace, exception.Message);
        }

        [Test]
        public void To_ShouldCorrectlyBeSet()
        {
            Assert.AreEqual(expectedReceiver, transaction.To);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("\t")]
        [TestCase("\u3000")]
        public void To_ShouldThrowException_WhenGivenNullOrWhiteSpace(string invalidReceiver)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    new Transaction(expectedId, expectedStatus, expectedSender, invalidReceiver, expectedAmount);
                });

            Assert.AreEqual(TransactionExceptions.ReceiverMustNotBeNullOrWhiteSpace, exception.Message);
        }

        [Test]
        public void Amount_ShouldCorrectlyBeSet()
        {
            Assert.AreEqual(expectedAmount, transaction.Amount);
        }

        [Test]
        public void Amount_ShouldThrowException_WhenGivenNegativeNumber()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    new Transaction(expectedId, expectedStatus, expectedSender, expectedReceiver, -1);
                });

            Assert.AreEqual(TransactionExceptions.AmountMustBePositive, exception.Message);
        }
    }
}
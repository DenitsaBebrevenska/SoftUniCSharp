using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    public class ShopTests
    {
        private Shop shop;
        private Shop invalidShop;
        private int capacity = 2;
        private Smartphone phone1;
        private Smartphone phone2;
        private Smartphone phone3;
        private string model1 = "Samsung";
        private string model2 = "Nokia";
        private string model3 = "Apple";
        private int maximumBatteryCharge = 100;

        [SetUp]
        public void SetUp()
        {
            shop = new Shop(capacity);
            phone1 = new Smartphone(model1, maximumBatteryCharge);
            phone2 = new Smartphone(model2, maximumBatteryCharge);
            phone3 = new Smartphone(model3, maximumBatteryCharge);
        }

        [Test]
        public void Constructor_ShouldInitializeShop()
        {
            Assert.IsNotNull(shop);
        }

        [Test]
        public void Constructor_ShouldSetCapacityCorrectly()
        {
            Assert.AreEqual(capacity, shop.Capacity);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void Capacity_ShouldThrowException_WhenGivenNegativeValue(int invalidCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                invalidShop = new Shop(invalidCapacity));
            Assert.AreEqual("Invalid capacity.", exception.Message);
        }

        [Test]
        public void Count_ShouldBeSetToZeroInitially()
        {
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void AddPhone_ShouldIncrementCount()
        {
            int phoneCount = 0;
            Assert.AreEqual(phoneCount, shop.Count);
            shop.Add(phone1);
            Assert.AreEqual(++phoneCount, shop.Count);
            shop.Add(phone2);
            Assert.AreEqual(++phoneCount, shop.Count);
        }

        [Test]
        public void AddPhone_ShouldThrowException_WhenPhoneIsAlreadyAtTheShop()
        {
            shop.Add(phone1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                shop.Add(phone1));
            Assert.AreEqual($"The phone model {model1} already exist.", exception.Message);
        }

        [Test]
        public void AddPhone_ShouldThrowException_WhenShopAtFullCapacity()
        {
            shop.Add(phone1);
            shop.Add(phone2);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                shop.Add(phone3));
            Assert.AreEqual($"The shop is full.", exception.Message);
        }

        [Test]
        public void RemovePhone_ShouldDecrementCount()
        {
            shop.Add(phone1);
            shop.Add(phone2);
            int phoneCount = 2;
            Assert.AreEqual(phoneCount, shop.Count);
            shop.Remove(model1);
            Assert.AreEqual(--phoneCount, shop.Count);
            shop.Remove(model2);
            Assert.AreEqual(--phoneCount, shop.Count);
        }

        [Test]
        public void RemovePhone_ShouldThrowException_WhenPhoneIsNotPresent()
        {
            shop.Add(phone1);
            shop.Add(phone2);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                shop.Remove(model3));
            Assert.AreEqual($"The phone model {model3} doesn't exist.", exception.Message);
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(50)]
        public void TestPhone_ShouldReduceCurrentBatteryCharge(int batteryUsage)
        {
            shop.Add(phone1);
            shop.TestPhone(model1, batteryUsage);
            Assert.AreEqual(maximumBatteryCharge - batteryUsage, phone1.CurrentBateryCharge);
        }

        [Test]
        public void TestPhone_ShouldThrowException_WhenPhoneIsNotPresent()
        {
            shop.Add(phone1);
            shop.Add(phone2);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                shop.TestPhone(model3, maximumBatteryCharge));
            Assert.AreEqual($"The phone model {model3} doesn't exist.", exception.Message);
        }

        [Test]
        public void TestPhone_ShouldThrowException_WhenInsufficientBattery()
        {
            shop.Add(phone1);
            int overflowBatteryUsage = maximumBatteryCharge + 1;
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                shop.TestPhone(model1, overflowBatteryUsage));
            Assert.AreEqual($"The phone model {model1} is low on batery.", exception.Message);
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(100)]
        public void ChargePhone_ShouldSetCurrentBatteryChargeBackToMaximum(int batteryUsage)
        {
            shop.Add(phone1);
            shop.TestPhone(model1, batteryUsage);
            Assert.IsTrue(phone1.CurrentBateryCharge < maximumBatteryCharge);
            shop.ChargePhone(model1);
            Assert.AreEqual(phone1.CurrentBateryCharge, maximumBatteryCharge);
        }

        [Test]
        public void ChargePhone_ShouldThrowException_WhenPhoneIsNotPresent()
        {
            shop.Add(phone1);
            shop.Add(phone2);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                shop.ChargePhone(model3));
            Assert.AreEqual($"The phone model {model3} doesn't exist.", exception.Message);
        }
    }
}
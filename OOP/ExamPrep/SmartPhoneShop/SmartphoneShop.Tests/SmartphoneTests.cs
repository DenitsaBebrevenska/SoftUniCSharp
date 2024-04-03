using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    public class SmartphoneTests
    {
        private Smartphone smartphone;
        private string model = "Samsung";
        private int maximumBatteryCharge = 100;

        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone(model, maximumBatteryCharge);
        }

        [Test]
        public void Constructor_ShouldInitializeSmartphone()
        {
            Assert.IsNotNull(smartphone);
        }

        [Test]
        public void ModelNameProperty_ShouldBeSetAndShouldGetCorrectly()
        {
            Assert.AreEqual(model, smartphone.ModelName);
        }

        [Test]
        public void MaximumBatteryChargeProperty_ShouldBeSetAndShouldGetCorrectly()
        {
            Assert.AreEqual(maximumBatteryCharge, smartphone.MaximumBatteryCharge);
        }

        [Test]
        public void Constructor_ShouldSetCurrentBatteryChargeToBeEqualToMaximum()
        {
            Assert.AreEqual(maximumBatteryCharge, smartphone.CurrentBateryCharge);
        }
    }
}
using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class VehicleTests
    {
        private Vehicle vehicle;
        private string brand = "Tesla";
        private string model = "X";
        private string licensePlateNumber = "EA2010XX";
        [SetUp]
        public void Setup()
        {
            vehicle = new Vehicle(brand, model, licensePlateNumber);
        }

        [Test]
        public void Constructor_ShouldInitializeVehicle()
        {
            Assert.IsNotNull(vehicle);
        }

        [Test]
        public void ModelProperty_ShouldBeSetCorrectlyAndReturnCorrectly()
        {
            Assert.AreEqual(model, vehicle.Model);
        }

        [Test]
        public void BrandProperty_ShouldBeSetCorrectlyAndReturnCorrectly()
        {
            Assert.AreEqual(brand, vehicle.Brand);
        }

        [Test]
        public void LicensePlateNumberProperty_ShouldBeSetCorrectlyAndReturnCorrectly()
        {
            Assert.AreEqual(licensePlateNumber, vehicle.LicensePlateNumber);
        }

        [Test]
        public void IsDamage_ShouldInitiallyBeSetToFalse()
        {
            Assert.IsFalse(vehicle.IsDamaged);
        }

        [Test]
        public void BatteryLevel_ShouldInitiallyBeSetTo100()
        {
            Assert.AreEqual(100, vehicle.BatteryLevel);
        }
    }
}
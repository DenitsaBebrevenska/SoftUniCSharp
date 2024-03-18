using NUnit.Framework;
using System.Linq;

namespace VehicleGarage.Tests
{
    public class GarageTests
    {
        private Garage garage;
        private int capacity = 2;
        private Vehicle vehicle;
        private Vehicle vehicle2;
        private string brand = "Tesla";
        private string model = "X";
        private string licensePlateNumber = "EA2010XX";
        private string licensePlateNumber2 = "CO0201HH";
        private int sampleBatteryDrainage = 50;

        [SetUp]
        public void Setup()
        {
            garage = new Garage(capacity);
            vehicle = new Vehicle(brand, model, licensePlateNumber);
            vehicle2 = new Vehicle(brand, model, licensePlateNumber2);
        }

        [Test]
        public void Constructor_ShouldInitializeGarage()
        {
            Assert.IsNotNull(garage);
        }

        [Test]
        public void Constructor_ShouldInitializeVehicleList()
        {
            Assert.IsNotNull(garage.Vehicles);
        }

        [Test]
        public void CapacityProperty_ShouldBeSetAndReturnCorrectly()
        {
            Assert.AreEqual(capacity, garage.Capacity);
        }

        [Test]
        public void AddVehicle_ShouldReturnTrue_WhenAVehicleIsAddedSuccessfully()
        {
            Assert.IsTrue(garage.AddVehicle(vehicle));
        }

        [Test]
        public void AddVehicle_ShouldAddVehicleToList_WhenAVehicleIsAddedSuccessfully()
        {
            Assert.IsFalse(garage.Vehicles.Contains(vehicle));
            garage.AddVehicle(vehicle);
            Assert.IsTrue(garage.Vehicles.Contains(vehicle));
        }

        [Test]
        public void AddVehicle_ShouldReturnFalse_WhenGarageAtMaxCapacity()
        {
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            Assert.AreEqual(garage.Capacity, garage.Vehicles.Count);
            Vehicle extraVehicle = new Vehicle("Mercedes", "AMG", "E3310CC");
            Assert.IsFalse(garage.AddVehicle(extraVehicle));
            Assert.IsFalse(garage.Vehicles.Contains(extraVehicle));
        }

        [Test]
        public void AddVehicle_ShouldReturnFalse_WhenThereIsAVehicleWithTheSamePlateNumber()
        {
            garage.AddVehicle(vehicle);
            Assert.IsTrue(garage.Vehicles.Contains(vehicle));
            Vehicle sameLicensePlateVehicle = new Vehicle("Opel", "Astra", licensePlateNumber);
            Assert.IsFalse(garage.AddVehicle(sameLicensePlateVehicle));
        }

        [Test]
        public void ChargeVehicles_ShouldReturnZero_IfAllVehicleBatteryLevelIsGreaterThanParameterBatteryLevel()
        {
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            Assert.AreEqual(0, garage.ChargeVehicles(50));
        }

        [Test]
        public void ChargeVehicles_ShouldUpdateVehicleBatteryLevelTo100()
        {
            vehicle.BatteryLevel = 40;
            garage.AddVehicle(vehicle);
            vehicle2.BatteryLevel = 50;
            garage.AddVehicle(vehicle2);
            garage.ChargeVehicles(50);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
        }

        [Test]
        public void ChargeVehicles_ShouldReturnCorrectlyCountOfChargedVehicles()
        {
            vehicle.BatteryLevel = 40;
            garage.AddVehicle(vehicle);
            vehicle2.BatteryLevel = 50;
            garage.AddVehicle(vehicle2);
            Assert.AreEqual(0, garage.ChargeVehicles(30));
            Assert.AreEqual(1, garage.ChargeVehicles(45));
            vehicle.BatteryLevel = 40;
            vehicle2.BatteryLevel = 50;
            Assert.AreEqual(2, garage.ChargeVehicles(50));
        }

        [Test]
        public void DriveVehicle_ShouldNotWork_IfVehicleIsDamaged()
        {
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle(licensePlateNumber, sampleBatteryDrainage, false);
            Assert.AreEqual(100, garage.Vehicles.First(v => v.LicensePlateNumber == licensePlateNumber).BatteryLevel);
            Assert.IsTrue(vehicle.IsDamaged);
        }

        [Test]
        public void DriveVehicle_ShouldNotWork_IfBatteryDrainageIsGreaterThan100()
        {
            sampleBatteryDrainage = 101;
            garage.AddVehicle(vehicle);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            garage.DriveVehicle(licensePlateNumber, sampleBatteryDrainage, false);
            Assert.AreEqual(100, vehicle.BatteryLevel);
        }

        [Test]
        public void DriveVehicle_ShouldNotWork_IfBatteryLevelIsLessThanBatteryDrainage()
        {
            sampleBatteryDrainage = 90;
            vehicle.BatteryLevel = 80;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle(licensePlateNumber, sampleBatteryDrainage, false);
            Assert.AreEqual(80, garage.Vehicles.First(v => v.LicensePlateNumber == licensePlateNumber).BatteryLevel);
        }

        [Test]
        public void DriveCar_WhenSuccessful_ShouldDecreaseBatteryLevelCorrectly()
        {
            garage.AddVehicle(vehicle);
            Assert.AreEqual(100, garage.Vehicles.First(v => v.LicensePlateNumber == licensePlateNumber).BatteryLevel);
            garage.DriveVehicle(vehicle.LicensePlateNumber, sampleBatteryDrainage, false);
            Assert.AreEqual(100 - sampleBatteryDrainage, garage.Vehicles.First(v => v.LicensePlateNumber == licensePlateNumber).BatteryLevel);
        }

        [Test]
        public void DriveCar_WhenSuccessful_ShouldChangeIsDamagedPropertyOfVehicle_WhenAccidentOccured()
        {
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.DriveVehicle(licensePlateNumber, sampleBatteryDrainage, true);
            garage.DriveVehicle(licensePlateNumber2, 50, false);
            Assert.IsTrue(vehicle.IsDamaged);
            Assert.IsFalse(vehicle2.IsDamaged);
        }

        [Test]
        public void RepairVehicles_ShouldChangeIsDamagedPropertyOfAVehicle()
        {
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);
            Assert.IsTrue(garage.Vehicles.First(v => v.LicensePlateNumber == licensePlateNumber).IsDamaged);
            garage.RepairVehicles();
            Assert.IsFalse(garage.Vehicles.First(v => v.LicensePlateNumber == licensePlateNumber).IsDamaged);
        }

        [Test]
        public void RepairVehicles_ShouldCorrectlyReturnStringWithCountOfRepairedVehicles()
        {
            int repairedVehicles = 0;
            string expectedResult = $"Vehicles repaired: {repairedVehicles}";
            garage.AddVehicle(vehicle);
            Assert.AreEqual(expectedResult, garage.RepairVehicles());
            garage.DriveVehicle(licensePlateNumber, 10, true);
            expectedResult = $"Vehicles repaired: {++repairedVehicles}";
            Assert.AreEqual(expectedResult, garage.RepairVehicles());
        }
    }
}
using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class GarageTests
    {
        private Garage garage;
        private int capacity = 5;
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
            Assert.AreEqual(0, garage.Vehicles.Count);
        }

        [Test]
        public void CapacityProperty_ShouldBeSetAndReturnCorrectly()
        {
            Assert.AreEqual(capacity, garage.Capacity);
            int newCapacity = 2;
            garage.Capacity = newCapacity;
            Assert.AreEqual(newCapacity, garage.Capacity);
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
            garage.Capacity = 1;
            garage.AddVehicle(vehicle);
            Assert.IsFalse(garage.AddVehicle(vehicle2));
            Assert.IsFalse(garage.Vehicles.Contains(vehicle2));
        }

        [Test]
        public void AddVehicle_ShouldReturnFalse_WhenThereIsVehicleWithTheSamePlateNumber()
        {
            garage.AddVehicle(vehicle);
            Assert.IsFalse(garage.AddVehicle(vehicle));
        }

        [Test]
        public void ChargeVehicles_ShouldReturnZero_IfAllVehicleBatteryLevelIsGreaterThanParameterBatteryLevel()
        {
            garage.AddVehicle(vehicle);
            vehicle.BatteryLevel = 90;
            garage.AddVehicle(vehicle2);
            vehicle2.BatteryLevel = 88;
            Assert.AreEqual(0, garage.ChargeVehicles(50));
        }

        [Test]
        public void ChargeVehicles_ShouldUpdateVehicleBatteryLevelTo100()
        {
            garage.AddVehicle(vehicle);
            vehicle.BatteryLevel = 40;
            garage.AddVehicle(vehicle2);
            vehicle2.BatteryLevel = 50;
            garage.ChargeVehicles(50);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
        }

        [Test]
        public void ChargeVehicles_ShouldReturnCorrectlyCountOfChargedVehicles()
        {
            garage.AddVehicle(vehicle);
            vehicle.BatteryLevel = 40;
            garage.AddVehicle(vehicle2);
            vehicle2.BatteryLevel = 50;
            Assert.AreEqual(0, garage.ChargeVehicles(30));
            Assert.AreEqual(2, garage.ChargeVehicles(50));
        }

        [Test]
        public void DriveVehicle_ShouldNotWork_IfVehicleIsDamaged()
        {
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle(vehicle.LicensePlateNumber, sampleBatteryDrainage, false);
            Assert.AreEqual(100, vehicle.BatteryLevel);
        }

        [Test]
        public void DriveVehicle_ShouldNotWork_IfBatteryDrainageIsGreaterThan100()
        {
            sampleBatteryDrainage = 101;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle(vehicle.LicensePlateNumber, sampleBatteryDrainage, false);
            Assert.AreEqual(100, vehicle.BatteryLevel);
        }

        [Test]
        public void DriveVehicle_ShouldNotWork_IfBatteryLevelIsLessThanBatteryDrainage()
        {
            sampleBatteryDrainage = 100;
            vehicle.BatteryLevel = 80;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle(vehicle.LicensePlateNumber, sampleBatteryDrainage, false);
            Assert.AreEqual(80, vehicle.BatteryLevel);
        }

        [Test]
        public void DriveCar_WhenSuccessful_ShouldDecreaseBatteryLevelCorrectly()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle(vehicle.LicensePlateNumber, sampleBatteryDrainage, false);
            Assert.AreEqual(100 - sampleBatteryDrainage, vehicle.BatteryLevel);
        }

        [Test]
        public void DriveCar_WhenSuccessful_ShouldChangeIsDamagedPropertyOfVehicle_WhenAccidentOccured()
        {
            garage.AddVehicle(vehicle);
            Assert.IsFalse(vehicle.IsDamaged);
            garage.DriveVehicle(vehicle.LicensePlateNumber, sampleBatteryDrainage, true);
            Assert.IsTrue(vehicle.IsDamaged);
        }

        [Test]
        public void RepairVehicles_ShouldChangeIsDamagedPropertyOfAVehicle()
        {
            garage.AddVehicle(vehicle);
            vehicle.IsDamaged = true;
            garage.RepairVehicles();
            Assert.IsFalse(vehicle.IsDamaged);
        }

        [Test]
        public void RepairVehicles_ShouldCorrectlyReturnStringWithCountOfRepairedVehicles()
        {
            int repairedVehicles = 0;
            string expectedResult = $"Vehicles repaired: {repairedVehicles}";
            garage.AddVehicle(vehicle);
            Assert.AreEqual(expectedResult, garage.RepairVehicles());
            vehicle.IsDamaged = true;
            expectedResult = $"Vehicles repaired: {++repairedVehicles}";
            Assert.AreEqual(expectedResult, garage.RepairVehicles());
        }
    }
}
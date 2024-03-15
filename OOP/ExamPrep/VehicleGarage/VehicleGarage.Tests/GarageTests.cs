using NUnit.Framework;
using System.Linq;

namespace VehicleGarage.Tests
{
    public class GarageTests
    {
        private Garage garage;
        private int capacity = 3;
        private Vehicle vehicle1;
        private Vehicle vehicle2;
        private Vehicle vehicle3;
        private Vehicle vehicle4;


        [SetUp]
        public void Setup()
        {
            garage = new Garage(capacity);
            vehicle1 = new Vehicle("Mercedes", "GLE", "CB0201AA");
            vehicle2 = new Vehicle("VW", "Transporter", "C0011BB");
            vehicle3 = new Vehicle("Skoda", "Fabia", "CA2014KA");
            vehicle4 = new Vehicle("Kawasaki", "Eliminator", "A2010CC");
        }

        [Test]
        public void Constructor_ShouldInitializeGarageAndSetCapacity()
        {
            Assert.IsNotNull(garage);
            Assert.AreEqual(capacity, garage.Capacity);
        }

        [Test]
        public void Constructor_InitializeTheListOfVehicles()
        {
            Assert.IsNotNull(garage.Vehicles);
        }

        [Test]
        public void AddVehicle_ShouldReturnFalse_IfGarageIsAtMaxCapacity()
        {
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            Assert.IsFalse(garage.AddVehicle(vehicle4));
        }

        [Test]
        public void AddVehicle_ShouldReturnFalse_IfThereIsAVehicleWithTheSameLicensePlateNumber()
        {
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            Assert.IsFalse(garage.AddVehicle(vehicle2));
        }

        [Test]
        public void AddVehicle_ShouldReturnTrue_WhenSuccessfullyAddingVehicle()
        {
            Assert.IsTrue(garage.AddVehicle(vehicle1));
        }

        [Test]
        public void AddVehicle_ShouldAddVehicleToVehicleList_WhenSuccessfullyAddingVehicle()
        {
            garage.AddVehicle(vehicle1);
            Assert.IsTrue(garage.Vehicles.Contains(vehicle1));
        }

        [Test]
        public void
            Charge_VehiclesShouldChargeNoVehiclesAndReturnCorrectCount_WhenAllVehiclesBatteryLevelsAreAboveGivenLevel()
        {
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            int batteryLevel = 60;
            Assert.IsTrue(garage.Vehicles.All(v => v.BatteryLevel > batteryLevel));
            Assert.AreEqual(0, garage.ChargeVehicles(batteryLevel));
        }

        [Test]
        public void
            Charge_VehiclesShouldChargeVehiclesWhoseBatteryIsLessOrEqualToGivenLevel()
        {
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.DriveVehicle("CB0201AA", 50, false);
            garage.DriveVehicle("C0011BB", 40, false);
            garage.DriveVehicle("CA2014KA", 30, false);
            int batteryLevel = 60;
            Assert.AreEqual(2, garage.Vehicles.Count(v => v.BatteryLevel <= batteryLevel));
            garage.ChargeVehicles(batteryLevel);
            Assert.AreEqual(100, garage.Vehicles.First(v => v.LicensePlateNumber == "CB0201AA").BatteryLevel);
            Assert.AreEqual(100, garage.Vehicles.First(v => v.LicensePlateNumber == "C0011BB").BatteryLevel);
        }

        [Test]
        public void
            Charge_VehiclesShouldReturnCorrectCountOfChargedVehicles()
        {
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.DriveVehicle("CB0201AA", 50, false);
            garage.DriveVehicle("CA2014KA", 40, false);
            garage.DriveVehicle("C0011BB", 30, false);
            int batteryLevel = 60;
            Assert.AreEqual(2, garage.Vehicles.Count(v => v.BatteryLevel <= batteryLevel));
            Assert.AreEqual(2, garage.ChargeVehicles(batteryLevel));
        }

        [Test]
        public void DriveVehicle_ShouldDrainBatteryLevelByGivenAmount()
        {
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle("CB0201AA", 60, false);
            Assert.AreEqual(40, vehicle1.BatteryLevel);
        }

        [Test]
        public void DriveVehicle_WhenAccidentOccur_ShouldChangeVehicleIsDamaged()
        {
            garage.AddVehicle(vehicle3);
            garage.DriveVehicle("CA2014KA", 60, true);
            Assert.IsTrue(vehicle3.IsDamaged);
        }


        [Test]
        public void DriveVehicle_ShouldDoNothing_IfVehicleIsDamaged()
        {
            vehicle3.IsDamaged = true;
            garage.AddVehicle(vehicle3);
            garage.DriveVehicle("CA2014KA", 60, true);
            Assert.AreEqual(100, vehicle3.BatteryLevel);
        }

        [Test]
        public void DriveVehicle_ShouldDoNothing_IfBatteryDrainageIsMoreThan100()
        {
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle("CB0201AA", 101, false);
            Assert.AreEqual(100, vehicle1.BatteryLevel);
        }

        [Test]
        public void DriveVehicle_ShouldDoNothing_IfBatteryLevelIsLessThanBatteryDrainage()
        {
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle("CB0201AA", 70, false);
            garage.DriveVehicle("CB0201AA", 50, false);
            Assert.AreEqual(30, vehicle1.BatteryLevel);
        }

        [Test]
        public void RepairVehicles_ShouldChangeIsDamagedToFalseToAllDamagedVehiclesAndReturnCorrectString()

        {
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.DriveVehicle("CB0201AA", 50, false);
            garage.DriveVehicle("CA2014KA", 40, true);
            garage.DriveVehicle("C0011BB", 30, true);
            Assert.AreEqual(2, garage.Vehicles.Count(v => v.IsDamaged));
            string expectedString = "Vehicles repaired: 2";
            Assert.AreEqual(expectedString, garage.RepairVehicles());
        }

        [Test]
        public void RepairVehicles_ShouldNotChangeIsDamagedToTrueAndReturnCorrectString_WhenNoDamagedVehicles()

        {
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.DriveVehicle("CB0201AA", 50, false);
            garage.DriveVehicle("CA2014KA", 40, false);
            garage.DriveVehicle("C0011BB", 30, false);
            Assert.AreEqual(0, garage.Vehicles.Count(v => v.IsDamaged));
            string expectedString = "Vehicles repaired: 0";
            Assert.AreEqual(expectedString, garage.RepairVehicles());
        }
    }
}
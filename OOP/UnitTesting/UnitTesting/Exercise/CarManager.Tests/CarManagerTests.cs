using NUnit.Framework.Internal;

namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        private string make = "Mercedes";
        private string model = "GLE";
        private double fuelConsumption = 10;
        private double fuelCapacity = 100;

        [Test]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void InitialFuelAmount_ShouldBeZero()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void SettingACarWithNullOrEmptyMake_ShouldThrowAnException(string incorrectMake)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    car = new Car(incorrectMake, model, fuelConsumption, fuelCapacity);
                });

            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void SettingACarWithNullOrEmptyModel_ShouldThrowAnException(string incorrectModel)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    car = new Car(make, incorrectModel, fuelConsumption, fuelCapacity);
                });

            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void SettingACarWithFuelConsumptionThatIsNotAPositiveNumber_ShouldThrowAnException(double incorrectFuelConsumption)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    car = new Car(make, model, incorrectFuelConsumption, fuelCapacity);
                });

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void SettingACarWithFuelCapacityThatIsNotAPositiveNumber_ShouldThrowAnException(double incorrectFuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    car = new Car(make, model, fuelConsumption, incorrectFuelCapacity);
                });

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void RefuelingACarWithFuelAmountThatIsNotAPositiveNumber_ShouldThrowAnException(double fuelAmount)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    car.Refuel(fuelAmount);
                });

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void RefuelingACar_ShouldIncreaseFuelAmountCorrectly()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            double fuelRefuel = 10;
            car.Refuel(fuelRefuel);
            Assert.AreEqual(fuelRefuel, car.FuelAmount);
        }

        [Test]
        public void RefuelingACarWithMoreFuelThanItsCapacity_ShouldSetTheAmountToCapacityLimit()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            double fuelRefuel = 200;
            car.Refuel(fuelRefuel);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        public void AttemptingToDriveACarThatHasNotEnoughFuel_ShouldThrowAnException()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            double distance = 100;

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    car.Drive(distance);
                });
            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }

        [Test]
        public void DrivingACarThatHasEnoughFuelForThat_ShouldCorrectlyReduceFuelAmount()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            double refuelFuel = 20;
            car.Refuel(refuelFuel);
            double distance = 1;
            car.Drive(distance);
            double expectedResult = refuelFuel - (distance / 100) * fuelConsumption;

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }
    }
}
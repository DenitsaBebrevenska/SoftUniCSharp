using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class GarageTests
    {
        private Garage garage;
        private string name = "RazzleDazzle";
        private int mechanicsAvailable = 2;
        private Car car1;
        private string modelCar1 = "X";
        private string modelCar2 = "Y";
        private string modelCar3 = "Z";
        private int issuesCar1 = 1;
        private int issuesCar2 = 2;
        private int issuesCar3 = 3;
        private Car car2;
        private Car car3;

        [SetUp]
        public void SetUp()
        {
            garage = new Garage(name, mechanicsAvailable);
            car1 = new Car(modelCar1, issuesCar1);
            car2 = new Car(modelCar2, issuesCar2);
            car3 = new Car(modelCar3, issuesCar3);
        }

        [Test]
        public void Constructor_ShouldInitializeGarage()
        {
            Assert.IsNotNull(garage);
        }

        [Test]
        public void Constructor_ShouldSetNumberOfCarToNumberOfCarCurrentlyInTheGarage()
        {
            Assert.AreEqual(0, garage.CarsInGarage);
        }

        [Test]
        public void Constructor_ShouldSetName()
        {
            Assert.AreEqual(name, garage.Name);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Name_ShouldThrowException_WhenValueIsNullOrEmpty(string invalidName)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                garage = new Garage(invalidName, mechanicsAvailable));
            Assert.AreEqual("Invalid garage name. (Parameter 'value')", exception.Message);
        }

        [Test]
        public void Constructor_ShouldSetMechanicsCount()
        {
            Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void MechanicsAvailable_ShouldThrowException_IsLessOrEqualToZero(int invalidMechanicCount)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                garage = new Garage(name, invalidMechanicCount));
            Assert.AreEqual("At least one mechanic must work in the garage.", exception.Message);
        }

        [Test]
        public void NumberOfCars_ShouldReturnCorrectNumberOfCarsInTheGarage()
        {
            garage.AddCar(car1);
            Assert.AreEqual(1, garage.CarsInGarage);
            garage.AddCar(car2);
            Assert.AreEqual(2, garage.CarsInGarage);
        }

        [Test]
        public void AddCar_ShouldAddCarToTheGarage()
        {
            int initialCarCount = garage.CarsInGarage;
            garage.AddCar(car1);
            Assert.IsTrue(garage.CarsInGarage > initialCarCount);
        }

        [Test]
        public void AddCar_ShouldThrowException_WhenAllMechanicsAreBusy()
        {
            garage.AddCar(car1);
            garage.AddCar(car2);
            Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                garage.AddCar(car3));
            Assert.AreEqual("No mechanic available.", exception.Message);
        }

        [Test]
        public void FixCar_ShouldSetNumberOfIssuesToZero()
        {
            garage.AddCar(car1);
            garage.FixCar(modelCar1);
            Assert.AreEqual(0, car1.NumberOfIssues);
        }

        [Test]
        public void FixCar_ShouldReturnCorrectCar()
        {
            garage.AddCar(car1);
            garage.AddCar(car2);
            Assert.AreSame(car1, garage.FixCar(modelCar1));
        }

        [Test]
        public void FixCar_ShouldReturnTheFirstCarOfGivenModel_WhenThereIsMoreThanOneOfTheSameModelInGarage()
        {
            garage.AddCar(car1);
            car2 = new Car(modelCar1, issuesCar2);
            garage.AddCar(car2);
            Assert.AreSame(car1, garage.FixCar(modelCar1));
        }

        [Test]
        public void FixCar_ShouldThrowException_IfNoSuchCarModelInTheGarage()
        {
            garage.AddCar(car1);
            garage.AddCar(car2);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                garage.FixCar(modelCar3));
            Assert.AreEqual($"The car {modelCar3} doesn't exist.", exception.Message);
        }

        [Test]
        public void RemoveFixedCar_ShouldRemoveFixedCarsFromTheGarage()
        {
            mechanicsAvailable++;
            garage = new Garage(name, mechanicsAvailable);
            garage.AddCar(car1);
            garage.AddCar(car2);
            garage.AddCar(car3);
            garage.FixCar(modelCar1);
            garage.FixCar(modelCar2);
            garage.RemoveFixedCar();
            Assert.AreEqual($"There are 1 which are not fixed: {car3.CarModel}.", garage.Report());
        }

        [Test]
        public void RemoveFixedCar_ShouldReturnCountOfFixedCars()
        {
            garage.AddCar(car1);
            garage.AddCar(car2);
            garage.AddCar(car3);
            garage.FixCar(modelCar1);
            garage.FixCar(modelCar2);
            int expectedResult = 2;
            Assert.AreEqual(expectedResult, garage.RemoveFixedCar());
        }

        [Test]
        public void RemoveFixedCar_ShouldThrowException_WhenNoFixedCarsAvailable()
        {
            garage.AddCar(car1);
            garage.AddCar(car2);
            garage.AddCar(car3);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                garage.RemoveFixedCar());
            Assert.AreEqual("No fixed cars available.", exception.Message);
        }

        [Test]
        public void Report_ShouldReturnCorrectly()
        {
            garage.AddCar(car1);
            garage.AddCar(car2);
            garage.AddCar(car3);
            garage.FixCar(modelCar1);
            string expectedResult = $"There are 2 which are not fixed: {car2.CarModel}, {car3.CarModel}.";
            Assert.AreEqual(expectedResult, garage.Report());
        }
    }
}
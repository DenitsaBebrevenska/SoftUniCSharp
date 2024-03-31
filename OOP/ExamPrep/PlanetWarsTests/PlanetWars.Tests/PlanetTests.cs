using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class PlanetTests
    {
        private Planet planet;
        private string name = "Melmac";
        private double budget = 2000;
        private Weapon weapon1;
        private Weapon weapon2;

        [SetUp]
        public void SetUp()
        {
            planet = new Planet(name, budget);
            weapon1 = new Weapon("Nuclear", 30, 200);
            weapon2 = new Weapon("SpaceGrenade", 2, 4);
        }

        [Test]
        public void Constructor_ShouldInitializePlanet()
        {
            Assert.IsNotNull(planet);
        }

        [Test]
        public void Constructor_ShouldInitializeWeaponList()
        {
            Assert.IsNotNull(planet.Weapons);
        }

        [Test]
        public void Constructor_ShouldSetNameCorrectly()
        {
            Assert.AreEqual(name, planet.Name);
        }

        [TestCase("")]
        [TestCase(null)]
        public void SettingNameToNullOrEmpty_ShouldThrowException(string invalidName)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                planet = new Planet(invalidName, budget));
            Assert.AreEqual("Invalid planet Name", exception.Message);
        }

        [Test]
        public void Constructor_ShouldSetBudgetCorrectly()
        {
            Assert.AreEqual(budget, planet.Budget);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void SettingBudgetToNegativeNumber_ShouldThrowException(double invalidBudget)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                planet = new Planet(name, invalidBudget));
            Assert.AreEqual("Budget cannot drop below Zero!", exception.Message);
        }

        //todo weapon collection + militaryRatio

        [TestCase(0)]
        [TestCase(20)]
        [TestCase(200)]
        public void Profit_ShouldIncreaseBudget(double profitAmount)
        {
            planet.Profit(profitAmount);
            Assert.AreEqual(budget + profitAmount, planet.Budget);
        }

        [TestCase(0)]
        [TestCase(20)]
        [TestCase(2000)]
        public void SpendFunds_ShouldDecreaseBudget(double decreaseAmount)
        {
            planet.SpendFunds(decreaseAmount);
            Assert.AreEqual(budget - decreaseAmount, planet.Budget);
        }

        [TestCase(2001)]
        [TestCase(3000)]
        [TestCase(20000)]
        public void SpendFunds_ShouldThrowException_WhenInsufficientBudget(double decreaseAmount)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                planet.SpendFunds(decreaseAmount));
            Assert.AreEqual("Not enough funds to finalize the deal.", exception.Message);
        }

        [Test]
        public void AddWeapon_ShouldAddItToTheWeaponList()
        {
            Assert.IsFalse(planet.Weapons.Contains(weapon1));
            planet.AddWeapon(weapon1);
            Assert.IsTrue(planet.Weapons.Contains(weapon1));
        }
        [Test]
        public void AddWeapon_ShouldThrowException_WhenTryingToAddWeaponThatAlreadyExists()
        {
            planet.AddWeapon(weapon1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                planet.AddWeapon(weapon1));
            Assert.AreEqual($"There is already a {weapon1.Name} weapon.", exception.Message);
        }
    }
}

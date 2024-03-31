using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class WeaponTests
    {
        private Weapon weapon;
        private Weapon weapon2;
        private string name = "Nuclear";
        private double price = 30;
        private int destructionLevel = 200;
        private int lesserDestructionLevel = 2;

        [SetUp]
        public void SetUp()
        {
            weapon = new Weapon(name, price, destructionLevel);
        }

        [Test]
        public void Constructor_ShouldInitializeWeapon()
        {
            Assert.IsNotNull(weapon);
        }

        [Test]
        public void Constructor_ShouldSetNameCorrectly()
        {
            Assert.AreEqual(name, weapon.Name);
        }

        [Test]
        public void Constructor_ShouldSetPriceCorrectly()
        {
            Assert.AreEqual(price, weapon.Price);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void SettingPriceToNegativeNumber_ShouldThrowException(int invalidPrice)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                weapon2 = new Weapon(name, invalidPrice, destructionLevel));
            Assert.AreEqual("Price cannot be negative.", exception.Message);
        }

        [Test]
        public void Constructor_ShouldSetDestructionLevelCorrectly()
        {
            Assert.AreEqual(destructionLevel, weapon.DestructionLevel);
        }

        [Test]
        public void IncreaseDestructionLevel_ShouldIncrementDestructionLevel()
        {
            weapon.IncreaseDestructionLevel();
            Assert.AreEqual(++destructionLevel, weapon.DestructionLevel);
            weapon.IncreaseDestructionLevel();
            Assert.AreEqual(++destructionLevel, weapon.DestructionLevel);
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(300)]
        public void IsNuclear_ShouldReturnTrue_WhenDestructionLevelEqualOrOver10(int nuclearDestructionLevel)
        {
            weapon2 = new Weapon(name, price, nuclearDestructionLevel);
            Assert.IsTrue(weapon2.IsNuclear);
        }

        [TestCase(9)]
        [TestCase(0)]
        [TestCase(-10)]
        public void IsNuclear_ShouldReturnFalse_WhenDestructionLevelLessThan10(int nonNuclearDestructionLevel)
        {
            weapon2 = new Weapon(name, price, nonNuclearDestructionLevel);
            Assert.IsFalse(weapon2.IsNuclear);
        }
    }
}

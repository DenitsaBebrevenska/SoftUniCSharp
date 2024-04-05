using NUnit.Framework;
using System;

namespace Robots.Tests
{
    public class RobotManagerTests
    {
        private RobotManager robotManager;
        private int capacity = 2;
        private Robot robot1;
        private Robot robot2;
        private Robot robot3;
        private string name1 = "Selena";
        private string name2 = "George";
        private string name3 = "Zahari";
        private int maxBattery = 100;

        [SetUp]
        public void SetUp()
        {
            robotManager = new RobotManager(capacity);
            robot1 = new Robot(name1, maxBattery);
            robot2 = new Robot(name2, maxBattery);
            robot3 = new Robot(name3, maxBattery);
        }

        [Test]
        public void Constructor_ShouldInitializeRobotManager()
        {
            Assert.IsNotNull(robotManager);
        }

        [Test]
        public void Capacity_ShouldBeSetAndGottenCorrectly()
        {
            Assert.AreEqual(capacity, robotManager.Capacity);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void Capacity_ShouldThrowException_WhenGivenNegativeNumber(int invalidCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                robotManager = new RobotManager(invalidCapacity));
            Assert.AreEqual("Invalid capacity!", exception.Message);
        }

        [Test]
        public void Count_ShouldInitiallyBeZero()
        {
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void Count_ShouldIncrease_WhenAddingARobot()
        {
            int currentCount = robotManager.Count;
            robotManager.Add(robot1);
            Assert.AreEqual(++currentCount, robotManager.Count);
            robotManager.Add(robot2);
            Assert.AreEqual(++currentCount, robotManager.Count);
        }

        [Test]
        public void Count_ShouldDecrease_WhenRemovingARobot()
        {
            robotManager.Add(robot2);
            robotManager.Add(robot3);
            int currentCount = robotManager.Count;
            robotManager.Remove(name2);
            Assert.AreEqual(--currentCount, robotManager.Count);
            robotManager.Remove(name3);
            Assert.AreEqual(--currentCount, robotManager.Count);
        }

        [Test]
        public void Add_ShouldThrowException_WhenTryingToAddAnExistingRobot()
        {
            robotManager.Add(robot1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                robotManager.Add(robot1));
            Assert.AreEqual($"There is already a robot with name {name1}!", exception.Message);
        }

        [Test]
        public void Add_ShouldThrowException_WhenCapacityIsFull()
        {
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                robotManager.Add(robot3));
            Assert.AreEqual($"Not enough capacity!", exception.Message);
        }

        [Test]
        public void Remove_ShouldThrowException_WhenTryingToRemoveANonExistentRobot()
        {
            robotManager.Add(robot1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                robotManager.Remove(name2));
            Assert.AreEqual($"Robot with the name {name2} doesn't exist!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(80)]
        [TestCase(100)]
        public void Work_ShouldReduceBatteryLevelCorrectly(int batteryDrainage)
        {
            robotManager.Add(robot1);
            robotManager.Work(name1, "", batteryDrainage);
            Assert.AreEqual(maxBattery - batteryDrainage, robot1.Battery);
        }

        [TestCase(101)]
        [TestCase(200)]
        [TestCase(800)]
        public void Work_ShouldThrowException_WhenBatteryUsageIsMoreThanBatteryLevel(int batteryDrainage)
        {
            robotManager.Add(robot1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                robotManager.Work(name1, "", batteryDrainage));
            Assert.AreEqual($"{name1} doesn't have enough battery!", exception.Message);
            Assert.AreEqual(maxBattery, robot1.Battery);
        }

        [Test]
        public void Work_ShouldThrowException_WhenTryingToWorkWithNonExistentRobot()
        {
            robotManager.Add(robot1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                robotManager.Work(name2, "", 0));
            Assert.AreEqual($"Robot with the name {name2} doesn't exist!", exception.Message);
        }

        [Test]
        public void Charge_ShouldSetCurrentBatteryLevelToMaximum()
        {
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Work(name1, "", 50);
            robotManager.Work(name2, "", 100);
            Assert.That(maxBattery > robot1.Battery);
            Assert.That(maxBattery > robot2.Battery);
            robotManager.Charge(name1);
            robotManager.Charge(name2);
            Assert.AreEqual(maxBattery, robot1.Battery);
            Assert.AreEqual(maxBattery, robot2.Battery);
        }

        [Test]
        public void Charge_ShouldThrowException_WhenTryingToChargeWithNonExistentRobot()
        {
            robotManager.Add(robot1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                robotManager.Charge(name2));
            Assert.AreEqual($"Robot with the name {name2} doesn't exist!", exception.Message);
        }
    }
}

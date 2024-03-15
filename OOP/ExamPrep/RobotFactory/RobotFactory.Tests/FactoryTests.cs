using NUnit.Framework;
using System.Linq;

namespace RobotFactory.Tests
{
    public class FactoryTests
    {
        private Factory factory;
        private string name = "Samsung";
        private int capacity = 2;


        [SetUp]
        public void Setup()
        {
            factory = new Factory(name, capacity);
        }

        [Test]
        public void Constructor_ShouldInitializeFactoryAndSetPropertiesCorrectly()
        {
            Assert.IsNotNull(factory);
            Assert.AreEqual(name, factory.Name);
            Assert.AreEqual(capacity, factory.Capacity);
        }

        [Test]
        public void Constructor_ShouldInitializeRobotsAndSupplements()
        {
            Assert.IsNotNull(factory.Supplements);
            Assert.IsNotNull(factory.Robots);
        }

        [Test]
        public void ProduceRobot_ShouldReturnCorrectString_WhenCapacityIsAtMax()
        {
            factory.ProduceRobot("any", 10, 20);
            factory.ProduceRobot("small", 2000, 5055);
            Assert.AreEqual(capacity, factory.Robots.Count);
            string expectedResult = "The factory is unable to produce more robots for this production day!";
            Assert.AreEqual(expectedResult, factory.ProduceRobot("some", 222, 1011));
        }

        [Test]
        public void ProduceRobot_ShouldAddRobotToRobotList()
        {
            Assert.IsFalse(factory.Robots.Any(r => r.Model == "any"));
            factory.ProduceRobot("any", 20, 202);
            Assert.IsTrue(factory.Robots.Any(r => r.Model == "any"));
        }

        [Test]
        public void ProduceRobot_ShouldReturnCorrectString_WhenSuccessfullyProducingARobot()
        {
            Robot robot = new Robot("some", 222, 1011);
            string expectedResult = $"Produced --> {robot}";
            Assert.AreEqual(expectedResult, factory.ProduceRobot("some", 222, 1011));
        }

        [Test]
        public void ProduceSupplement_ShouldReturnCorrectString()
        {
            Supplement supplement = new Supplement("Fork", 10);
            Assert.AreEqual(supplement.ToString(), factory.ProduceSupplement("Fork", 10));
        }

        [Test]
        public void ProduceSupplement_ShouldAddProducedSupplementToList()
        {
            Assert.IsFalse(factory.Supplements.Any(s => s.Name == "Fork"));
            factory.ProduceSupplement("Fork", 10);
            Assert.IsTrue(factory.Supplements.Any(s => s.Name == "Fork"));
        }


        [Test]
        public void UpgradeRobot_ShouldAddSupplementToRobot_WhenInterfaceStandardsAreTheSameAndRobotDoesNotHaveThatSupplementAlready()
        {
            Robot robot = new Robot("some", 222, 10);
            Supplement supplement = new Supplement("Fork", 10);
            Assert.IsFalse(robot.Supplements.Contains(supplement));
            factory.UpgradeRobot(robot, supplement);
            Assert.IsTrue(robot.Supplements.Contains(supplement));
        }

        [Test]
        public void UpgradeRobot_ShouldReturnTrue_WhenSupplementIsSuccessfullyAdded()
        {
            Robot robot = new Robot("some", 222, 10);
            Supplement supplement = new Supplement("Fork", 10);
            Assert.IsTrue(factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void UpgradeRobot_ShouldReturnFalse_WhenRobotAlreadyHasThatSupplement()
        {
            Robot robot = new Robot("some", 222, 10);
            Supplement supplement = new Supplement("Fork", 10);
            Assert.IsTrue(factory.UpgradeRobot(robot, supplement));
            Assert.IsTrue(robot.Supplements.Contains(supplement));
            Assert.IsFalse(factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void UpgradeRobot_ShouldReturnFalseAndNotAddSupplement_WhenRobotAndSupplementInterfaceStandardsDiffer()
        {
            Robot robot = new Robot("some", 222, 2020);
            Supplement supplement = new Supplement("Fork", 10);
            Assert.IsFalse(robot.Supplements.Contains(supplement));
            Assert.IsFalse(factory.UpgradeRobot(robot, supplement));
            Assert.IsFalse(robot.Supplements.Contains(supplement));
        }

        [Test]
        public void SellRobot_ReturnsTheFirstMostExpensiveRobotThatIsLessIfNoEqualToGivenPrice()
        {
            factory.Capacity = 3;
            factory.ProduceRobot("some", 222, 2020);
            factory.ProduceRobot("same", 60, 2222);
            factory.ProduceRobot("any", 100, 1247);
            Robot robot = new Robot("any", 100, 1247);
            Assert.AreEqual(robot.Model, factory.SellRobot(120).Model);
        }

        [Test]
        public void SellRobot_ReturnsTheFirstRobotWhosePriceIsEqualToGivenPrice()
        {
            factory.Capacity = 3;
            factory.ProduceRobot("some", 222, 2020);
            factory.ProduceRobot("same", 60, 2222);
            factory.ProduceRobot("any", 100, 1247);
            Robot robot = new Robot("same", 60, 2222);
            Assert.AreEqual(robot.Model, factory.SellRobot(60).Model);
        }
    }
}
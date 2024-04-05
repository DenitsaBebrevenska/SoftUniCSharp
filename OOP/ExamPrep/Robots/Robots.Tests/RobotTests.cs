using NUnit.Framework;

namespace Robots.Tests
{
    public class RobotTests
    {
        private Robot robot;
        private string name = "Selena";
        private int maximumBattery = 100;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot(name, maximumBattery);
        }

        [Test]
        public void Constructor_ShouldInitializeRobot()
        {
            Assert.IsNotNull(robot);
        }

        [Test]
        public void MaximumBattery_ShouldBeSetAndGottenCorrectly()
        {
            Assert.AreEqual(maximumBattery, robot.MaximumBattery);
        }

        [Test]
        public void Battery_ShouldBeSetAndGottenCorrectly()
        {
            Assert.AreEqual(maximumBattery, robot.Battery);
        }
    }
}

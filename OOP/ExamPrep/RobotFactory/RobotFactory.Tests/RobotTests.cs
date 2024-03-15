using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class RobotTests
    {
        private Robot robot;
        private string model = "DomesticAssistant";
        private double price = 1000.90;
        private int interfaceStandard = 1024;

        [SetUp]
        public void Setup()
        {
            robot = new Robot(model, price, interfaceStandard);
        }

        [Test]
        public void Constructor_ShouldInitializeRobotAndSetProperties()
        {
            Assert.IsNotNull(robot);
            Assert.AreEqual(model, robot.Model);
            Assert.AreEqual(price, robot.Price);
            Assert.AreEqual(interfaceStandard, robot.InterfaceStandard);
        }

        [Test]
        public void Constructor_InitializeTheListOfSupplements()
        {
            Assert.IsNotNull(robot.Supplements);
        }

        [Test]
        public void ToString_ShouldReturnCorrectly()
        {
            string expectedResult = $"Robot model: {model} IS: {interfaceStandard}, Price: {price:f2}";
            Assert.AreEqual(expectedResult, robot.ToString());
        }
    }
}
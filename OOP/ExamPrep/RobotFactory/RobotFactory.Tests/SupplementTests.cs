using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class SupplementTests
    {
        private Supplement supplement;
        private string name = "LaserRadar";
        private int interfaceStandard = 1024;

        [SetUp]
        public void Setup()
        {
            supplement = new Supplement(name, interfaceStandard);
        }

        [Test]
        public void Constructor_ShouldInitializeSupplementAndSetCorrectProperties()
        {
            Assert.IsNotNull(supplement);
            Assert.AreEqual(name, supplement.Name);
            Assert.AreEqual(interfaceStandard, supplement.InterfaceStandard);
        }

        [Test]
        public void ToString_ShouldReturnCorrectly()
        {
            string expectedResult = $"Supplement: {name} IS: {interfaceStandard}";
            Assert.AreEqual(expectedResult, supplement.ToString());
        }
    }
}
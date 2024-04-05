using NUnit.Framework;

namespace Gyms.Tests
{
    public class AthleteTests
    {
        private Athlete athlete;
        private string name = "Usain Bolt";

        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete(name);
        }

        [Test]
        public void Constructor_ShouldInitializeAthlete()
        {
            Assert.IsNotNull(athlete);
        }

        [Test]
        public void FullName_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(name, athlete.FullName);
        }

        [Test]
        public void IsInjured_ShouldBeSetToFalse()
        {
            Assert.IsFalse(athlete.IsInjured);
        }
    }
}

using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Gym gym;
        private Gym invalidGym;
        private string gymName = "Olympic";
        private int size = 2;
        private Athlete athlete1;
        private string athleteName1 = "Usain Bolt";
        private Athlete athlete2;
        private string athleteName2 = "Tom Brandy";
        private Athlete athlete3;
        private string athleteName3 = "LeBron James";

        [SetUp]
        public void SetUp()
        {
            gym = new Gym(gymName, size);
            athlete1 = new Athlete(athleteName1);
            athlete2 = new Athlete(athleteName2);
            athlete3 = new Athlete(athleteName3);
        }

        [Test]
        public void Constructor_ShouldInitializeGym()
        {
            Assert.IsNotNull(gym);
        }

        [Test]
        public void NameProperty_ShouldBeSetAndGottenCorrectly()
        {
            Assert.AreEqual(gymName, gym.Name);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameProperty_ShouldThrowException_WhenNameIsNullOrEmpty(string invalidName)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                invalidGym = new Gym(invalidName, size));
            Assert.AreEqual("Invalid gym name. (Parameter 'value')", exception.Message);
            Assert.AreEqual("value", exception.ParamName);
        }

        [Test]
        public void CapacityProperty_ShouldBeSetAndGottenCorrectly()
        {
            Assert.AreEqual(size, gym.Capacity);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void CapacityProperty_ShouldThrowException_WhenCapacityIsNegative(int invalidSize)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                invalidGym = new Gym(gymName, invalidSize));
            Assert.AreEqual("Invalid gym capacity.", exception.Message);
        }

        [Test]
        public void Count_ShouldInitiallyBeSetToZero()
        {
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void Count_ShouldIncrease_WhenAddingAthlete()
        {
            int initialCount = gym.Count;
            gym.AddAthlete(athlete1);
            Assert.AreEqual(++initialCount, gym.Count);
            gym.AddAthlete(athlete2);
            Assert.AreEqual(++initialCount, gym.Count);
        }

        [Test]
        public void Count_ShouldDecrease_WhenRemoveAthlete()
        {
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            int initialCount = gym.Count;
            gym.RemoveAthlete(athleteName1);
            Assert.AreEqual(--initialCount, gym.Count);
            gym.RemoveAthlete(athleteName2);
            Assert.AreEqual(--initialCount, gym.Count);
        }

        [Test]
        public void AddingAthlete_WhenCapacityIsFull_ShouldThrowException()
        {
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                gym.AddAthlete(athlete3));
            Assert.AreEqual("The gym is full.", exception.Message);
        }

        [Test]
        public void RemovingAthlete_WhenThatAthleteIsNotInTheGym_ShouldThrowException()
        {
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                gym.RemoveAthlete(athleteName3));
            Assert.AreEqual($"The athlete {athleteName3} doesn't exist.", exception.Message);
        }

        [Test]
        public void InjureAthlete_ShouldSetAthleteIsInjuredToTrue()
        {
            gym.AddAthlete(athlete1);
            Assert.IsFalse(athlete1.IsInjured);
            gym.InjureAthlete(athleteName1);
            Assert.IsTrue(athlete1.IsInjured);
        }

        [Test]
        public void InjureAthlete_ShouldReturnTheCorrectAthlete()
        {
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete3);

            Assert.AreSame(athlete1, gym.InjureAthlete(athleteName1));
        }

        [Test]
        public void InjureAthlete_WhenThatAthleteIsNotInTheGym_ShouldThrowException()
        {
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                gym.InjureAthlete(athleteName3));
            Assert.AreEqual($"The athlete {athleteName3} doesn't exist.", exception.Message);
        }
        [Test]
        public void Report_ShouldReturnCorrectly()
        {
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.InjureAthlete(athleteName1);
            string expectedResult = $"Active athletes at {gym.Name}: {athleteName2}";
            Assert.AreEqual(expectedResult, gym.Report());
        }
    }
}

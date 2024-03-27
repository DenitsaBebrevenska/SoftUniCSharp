using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class FootballPlayerTests
    {
        private FootballPlayer player;
        private FootballPlayer player2;
        private FootballPlayer player3;
        private int number = 8;
        private string name = "Stoichkov";
        private string position = "Forward";

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer(name, number, position);
        }

        [Test]
        public void Constructor_ShouldInitializePlayer()
        {
            Assert.IsNotNull(player);
        }

        [Test]
        public void Constructor_ShouldSetNameCorrectly()
        {
            Assert.AreEqual(name, player.Name);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Name_ShouldThrowException_IfNameIsNullOrEmpty(string invalidName)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                player2 = new FootballPlayer(invalidName, number, position));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [Test]
        public void Constructor_ShouldSetNumberCorrectly()
        {
            Assert.AreEqual(number, player.PlayerNumber);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(22)]
        [TestCase(50)]
        public void PlayerNumber_ShouldThrowException_IfNumberNotInRange(int invalidNumber)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                player2 = new FootballPlayer(name, invalidNumber, position));
            Assert.AreEqual("Player number must be in range [1,21]", exception.Message);
        }

        [Test]
        public void Constructor_ShouldSetPositionCorrectly()
        {
            Assert.AreEqual(position, player.Position);
            string goalKeeper = "Goalkeeper";
            string mid = "Midfielder";
            player2 = new FootballPlayer(name, number, goalKeeper);
            Assert.AreEqual(goalKeeper, player2.Position);
            player3 = new FootballPlayer(name, number, mid);
            Assert.AreEqual(mid, player3.Position);
        }

        [TestCase("goalkeeper")]
        [TestCase("Midfield")]
        [TestCase("any")]
        public void Position_ShouldThrowException_WhenInvalidPositionOrIncorrectLetterCase(string invalidPosition)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                player2 = new FootballPlayer(name, number, invalidPosition));
            Assert.AreEqual("Invalid Position", exception.Message);
        }


        [Test]
        public void Constructor_ShouldSetScoredGoalsToZero()
        {
            Assert.AreEqual(0, player.ScoredGoals);
        }

        [Test]
        public void Score_ShouldIncreaseGoalCount()
        {
            int goalCount = 0;
            player.Score();
            Assert.AreEqual(++goalCount, player.ScoredGoals);
            player.Score();
            Assert.AreEqual(++goalCount, player.ScoredGoals);
        }
    }
}
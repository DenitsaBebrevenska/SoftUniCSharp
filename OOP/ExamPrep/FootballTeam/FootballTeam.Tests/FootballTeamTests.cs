using NUnit.Framework;
using System;
using System.Linq;

namespace FootballTeam.Tests
{
    public class FootballTeamTests
    {
        private FootballPlayer player1;
        private FootballPlayer player2;
        private FootballPlayer player3;
        private FootballTeam team;
        private FootballTeam team2;
        private string name = "Barcelona";
        private int capacity = 20;
        private string name1 = "Stoichkov";
        private int number1 = 8;
        private string position1 = "Forward";
        private string name2 = "Carlos";
        private int number2 = 20;
        private string position2 = "Goalkeeper";

        [SetUp]
        public void Setup()
        {
            team = new FootballTeam(name, capacity);
        }

        [Test]
        public void Constructor_ShouldInitializeTeam()
        {
            Assert.IsNotNull(team);
        }

        [Test]
        public void Constructor_ShouldInitializePlayers()
        {
            Assert.IsNotNull(team.Players);
        }

        [Test]
        public void Constructor_ShouldSetNameCorrectly()
        {
            Assert.AreEqual(name, team.Name);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Name_ShouldThrowException_IfNameIsNullOrEmpty(string invalidName)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                team2 = new FootballTeam(invalidName, capacity));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [Test]
        public void Constructor_ShouldSetCapacityCorrectly()
        {
            Assert.AreEqual(capacity, team.Capacity);
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(14)]
        public void Capacity_ShouldThrowException_IfCapacityIsLessThan15(int invalidCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                team2 = new FootballTeam(name, invalidCapacity));
            Assert.AreEqual("Capacity min value = 15", exception.Message);
        }

        [Test]
        public void AddNewPlayer_ShouldAddPlayerToPlayerList()
        {
            player1 = new FootballPlayer(name1, number1, position1);
            Assert.IsNull(team.PickPlayer(name1));
            Assert.IsFalse(team.Players.Any(p => p.Name == name1));
            team.AddNewPlayer(player1);
            Assert.IsNotNull(team.PickPlayer(name1));
            Assert.IsTrue(team.Players.Any(p => p.Name == name1));
        }

        [Test]
        public void AddNewPlayer_ShouldReturnCorrectString_WhenAddingPlayer()
        {
            player1 = new FootballPlayer(name1, number1, position1);
            string expectedResult = $"Added player {name1} in position {position1} with number {number1}";
            Assert.AreEqual(expectedResult, team.AddNewPlayer(player1));
        }

        [Test]
        public void AddNewPlayer_ShouldNotAddPlayerToPlayerList_WhenCapacityIsFull()
        {
            player1 = new FootballPlayer(name1, number1, position1);
            player2 = new FootballPlayer(name2, number2, position2);
            Assert.IsNull(team.PickPlayer(name2));
            Assert.IsFalse(team.Players.Any(p => p.Name == name2));

            for (int i = 0; i < capacity; i++)
            {
                team.AddNewPlayer(player1);
            }

            team.AddNewPlayer(player2);
            Assert.IsNull(team.PickPlayer(name2));
            Assert.IsFalse(team.Players.Any(p => p.Name == name2));
        }

        [Test]
        public void AddNewPlayer_ShouldReturnCorrectString_WhenUnableToAddPlayer()
        {
            player1 = new FootballPlayer(name1, number1, position1);

            for (int i = 0; i < capacity; i++)
            {
                team.AddNewPlayer(player1);
            }

            string expectedResult = "No more positions available!";

            Assert.AreEqual(expectedResult, team.AddNewPlayer(player1));
        }

        [Test]
        public void PickPlayer_ShouldReturnFirstPlayerWithGivenName()
        {
            player1 = new FootballPlayer(name1, number1, position1);
            player2 = new FootballPlayer(name1, number2, position2);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            Assert.AreSame(player1, team.PickPlayer(name1));
        }

        [Test]
        public void PickPlayer_ShouldReturnNull_IfNoPlayerByThatName()
        {
            player1 = new FootballPlayer(name1, number1, position1);
            player2 = new FootballPlayer(name2, number2, position2);
            team.AddNewPlayer(player2);
            Assert.IsNull(team.PickPlayer(name1));
            Assert.IsNull(team.PickPlayer(name));
        }

        [Test]
        public void PlayerScore_ShouldIncrementPlayerScore()
        {
            player1 = new FootballPlayer(name1, number1, position1);
            team.AddNewPlayer(player1);
            Assert.AreEqual(0, player1.ScoredGoals);
            team.PlayerScore(number1);
            Assert.AreEqual(1, player1.ScoredGoals);
            team.PlayerScore(number1);
            Assert.AreEqual(2, player1.ScoredGoals);
        }

        [Test]
        public void PlayerScore_ShouldReturnCorrectString()
        {
            player1 = new FootballPlayer(name1, number1, position1);
            team.AddNewPlayer(player1);
            team.PlayerScore(number1);
            string expectedResult = $"{name1} scored and now has 2 for this season!";
            Assert.AreEqual(expectedResult, team.PlayerScore(number1));
        }


        [Test]
        public void PlayerScore_ShouldTargetTheFirstPlayerWithThatName()
        {
            player1 = new FootballPlayer(name1, number1, position1);
            player2 = new FootballPlayer(name2, number1, position2);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            Assert.AreSame(player1, team.Players.FirstOrDefault(p => p.PlayerNumber == number1));
            team.PlayerScore(number1);
            Assert.AreEqual(1, player1.ScoredGoals);
            Assert.AreNotEqual(1, player2.ScoredGoals);
        }
    }
}
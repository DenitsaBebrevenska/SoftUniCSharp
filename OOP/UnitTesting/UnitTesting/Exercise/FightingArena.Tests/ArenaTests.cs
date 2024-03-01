using System.Collections.Generic;
using System.Linq;

namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Warrior warrior1;
        private Warrior warrior2;
        private Arena arena;

        private List<Warrior> warriors = new List<Warrior>();

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior1 = new Warrior("Grommash", 100, 200);
            warrior2 = new Warrior("Helscream", 50, 150);
        }

        [Test]
        public void Constructor_ShouldInitializeWarriorList()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void WarriorCollection_ShouldCorrectlyDisplayContestantsInIt()
        {
            warriors.Add(warrior1);
            warriors.Add(warrior2);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            Assert.AreEqual(warriors, arena.Warriors);
        }

        [Test]
        public void CountProperty_ShouldCorrectlyReturnCountOfContestants()
        {
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            Assert.AreEqual(2, arena.Count);
        }
        [Test]
        public void EnrollMethod_ShouldCorrectlyAddAWarriorToTheListOfWarriors()
        {
            arena.Enroll(warrior1);
            Assert.That(arena.Warriors.Contains(warrior1));
        }

        [Test]
        public void AttemptingToEnrollAWarriorWhoseNameIsAlreadyOnTheList_ShouldThrowAnException()
        {
            arena.Enroll(warrior1);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    arena.Enroll(warrior1);
                });
            Assert.AreEqual("Warrior is already enrolled for the fights!", ex.Message);
        }

        [Test]
        public void ArenaFightShouldWorkCorrectly()
        {
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            int expectedWarrior1Hp = warrior1.HP - warrior2.Damage;
            int expectedWarrior2Hp = warrior2.HP - warrior1.Damage;

            arena.Fight(warrior1.Name, warrior2.Name);

            Assert.AreEqual(expectedWarrior1Hp, warrior1.HP);
            Assert.AreEqual(expectedWarrior2Hp, warrior2.HP);
        }


        [TestCase("Simba")]
        [TestCase("Yoda")]
        public void StartingAFightBetweenContestantsOfWhomTheAttackerIsNotEnrolled_ShouldThrowAnException(string nonExistentAttacker)
        {
            arena.Enroll(warrior1);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    arena.Fight(nonExistentAttacker, warrior1.Name);
                });
            Assert.AreEqual($"There is no fighter with name {nonExistentAttacker} enrolled for the fights!", ex.Message);
        }

        [TestCase("Simba")]
        [TestCase("Yoda")]
        public void StartingAFightBetweenContestantsOfWhomDefenderIsNotEnrolled_ShouldThrowAnException(string nonExistentDefender)
        {
            arena.Enroll(warrior1);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    arena.Fight(warrior1.Name, nonExistentDefender);
                });
            Assert.AreEqual($"There is no fighter with name {nonExistentDefender} enrolled for the fights!", ex.Message);
        }
    }
}

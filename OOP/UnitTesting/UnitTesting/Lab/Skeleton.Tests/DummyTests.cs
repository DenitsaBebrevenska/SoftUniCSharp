using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Dummy deadDummy;
        private Dummy negativeHealthDummy;
        private readonly int health = 100;
        private readonly int experience = 10;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(health, experience);
            deadDummy = new Dummy(0, experience);
            negativeHealthDummy = new Dummy(-100, experience);
        }

        [Test]
        public void When_Health_Is_Given_It_Should_Be_Set_Correctly()
        {
            Assert.That(dummy.Health, Is.EqualTo(health));
        }
        [Test]
        public void Dummy_Should_Lose_Health_After_An_Attack()
        {
            int attackPoints = 10;
            dummy.TakeAttack(attackPoints);

            Assert.That(dummy.Health, Is.EqualTo(health - attackPoints), "Dummy doesn`t loose health when attacked");
        }

        [Test]
        public void A_Dummy_With_0_Health_Should_Throw_Exception_When_Attacked()
        {
            Assert.Throws<InvalidOperationException>(() =>
                {
                    deadDummy.TakeAttack(10);
                }, "Dummy has health of 0."
                );
        }

        [Test]

        public void A_Dead_Dummy_Gives_Experience()
        {
            Assert.AreEqual(deadDummy.GiveExperience(), experience);
        }

        [Test]
        public void Alive_Dummy_Should_Throw_Exception_When_Give_Experience_Is_Called()
        {
            Assert.Throws<InvalidOperationException>(() =>
                {
                    dummy.GiveExperience();
                }, "Dummy is not dead"
                );
        }
    }
}
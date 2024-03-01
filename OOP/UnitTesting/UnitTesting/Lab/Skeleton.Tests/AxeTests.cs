using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private int attack = 10;
        private int durability = 10;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(attack, durability);
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void When_Attack_And_Durability_Are_Give_They_Should_Be_Set_Correctly()
        {
            Assert.AreEqual(axe.AttackPoints, attack);
            Assert.AreEqual(axe.DurabilityPoints, durability);
        }

        [Test]
        public void Axe_Loses_One_Durability_After_Each_Attack()
        {
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn`t change after an attack");
        }

        [Test]
        public void A_Weapon_With_0_Durability_Should_Throw_An_Exception_When_Attempting_An_Attack()
        {
            axe = new Axe(10, 0);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }, "Axe`s durability is 0.");
        }

        [Test]
        public void An_Ax_Called_To_Attack_A_Null_Dummy_Should_Throw_Null_Reference_Exception()
        {
            Assert.Throws<NullReferenceException>(() =>
                {
                    axe.Attack(null);
                }, "Target to attack is null."
            );
        }
    }
}
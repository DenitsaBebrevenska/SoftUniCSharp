using Moq;
using NUnit.Framework;

namespace Skeleton.Tests
{
    public class HeroMockTests
    {
        [TestFixture]
        public class HeroTests
        {
            private Hero hero;
            private Mock<IWeapon> weapon;
            private Mock<ITarget> target;

            [SetUp]
            public void Setup()
            {
                weapon = new Mock<IWeapon>();
                target = new Mock<ITarget>();
                target.Setup(t => t.IsDead()).Returns(true);
                target.Setup(t => t.GiveExperience()).Returns(100);

                hero = new Hero("HeroName", weapon.Object);
            }

            [Test]
            public void Hero_Attack_ShouldIncreaseExperience_WhenTargetIsDead()
            {
                hero.Attack(target.Object);
                Assert.AreEqual(100, hero.Experience);
            }
        }
    }
}

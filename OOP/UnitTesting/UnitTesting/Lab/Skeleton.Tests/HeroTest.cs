using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        private Hero hero;
        private IWeapon weapon;
        private ITarget target;

        [SetUp]
        public void Setup()
        {
            weapon = new Axe(10, 10);
            target = new Dummy(10, 50);
            hero = new Hero("Conan", weapon);
        }

        [Test]
        public void Constructor_ShouldInitializeHero()
        {
            Assert.IsNotNull(hero);
        }

        [Test]
        public void HeroAttack_ShouldWorkCorrectly()
        {
            int expectedTargetHealth = target.Health - weapon.AttackPoints;
            hero.Attack(target);
            Assert.AreEqual(9, weapon.DurabilityPoints);
            Assert.AreEqual(expectedTargetHealth, target.Health);
        }

        [Test]
        public void HeroAttack_ShouldCauseExperienceGain_IfTargetDies()
        {
            hero.Attack(target);
            Assert.That(hero.Experience > 0);
        }
    }
}
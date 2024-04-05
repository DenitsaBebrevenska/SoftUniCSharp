using NUnit.Framework;

namespace HeroRepository.Tests
{
    public class HeroTests
    {
        private Hero hero;
        private string name;
        private int level;

        [SetUp]
        public void SetUp()
        {
            hero = new Hero(name, level);
        }

        [Test]
        public void Constructor_ShouldInitializeHero()
        {
            Assert.IsNotNull(hero);
        }

        [Test]
        public void Constructor_ShouldSetName()
        {
            Assert.AreEqual(name, hero.Name);
        }

        [Test]
        public void Constructor_ShouldSetLevel()
        {
            Assert.AreEqual(level, hero.Level);
        }
    }
}
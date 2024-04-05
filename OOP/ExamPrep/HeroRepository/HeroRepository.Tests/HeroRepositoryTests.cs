using NUnit.Framework;
using System;
using System.Linq;

namespace HeroRepository.Tests
{
    public class HeroRepositoryTests
    {
        private HeroRepository repository;
        private Hero hero1;
        private Hero hero2;
        private Hero hero3;
        private string name1 = "Zamba";
        private string name2 = "Speedy";
        private string name3 = "Pewdie";
        private int level1 = 59;
        private int level2 = 60;


        [SetUp]
        public void SetUp()
        {
            repository = new HeroRepository();
            hero1 = new Hero(name1, level1);
            hero2 = new Hero(name2, level2);
            hero3 = new Hero(name3, level2);
        }

        [Test]
        public void Constructor_ShouldInitializeHeroRepository()
        {
            Assert.IsNotNull(repository);
        }

        [Test]
        public void Constructor_InitializeHeroList()
        {
            Assert.IsNotNull(repository.Heroes);
        }

        [Test]
        public void Create_ShouldAddHeroToList()
        {
            Assert.IsFalse(repository.Heroes.Contains(hero1));
            repository.Create(hero1);
            Assert.IsTrue(repository.Heroes.Contains(hero1));
        }

        [Test]
        public void Create_ShouldReturnCorrectly()
        {
            Assert.AreEqual($"Successfully added hero {name1} with level {level1}", repository.Create(hero1));
        }

        [Test]
        public void Create_ShouldThrowException_WhenGivenNullHero()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                repository.Create(null));
            Assert.AreEqual("Hero is null (Parameter 'hero')", exception.Message);
            Assert.AreEqual("hero", exception.ParamName);
        }


        [Test]
        public void Create_ShouldThrowException_WhenTryingToAddAHeroWhoAlreadyExists()
        {
            repository.Create(hero1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                repository.Create(hero1));
            Assert.AreEqual($"Hero with name {name1} already exists", exception.Message);
        }

        [Test]
        public void Remove_ShouldRemoveHeroFromList()
        {
            repository.Create(hero1);
            Assert.IsTrue(repository.Heroes.Contains(hero1));
            repository.Remove(name1);
            Assert.IsFalse(repository.Heroes.Contains(hero1));
        }

        [Test]
        public void Remove_ShouldReturnTrue_WhenSuccessfullyRemoving()
        {
            repository.Create(hero1);
            Assert.IsTrue(repository.Remove(name1));
        }

        [Test]
        public void Remove_ShouldReturnFalse_WhenHeroIsNotInList()
        {
            repository.Create(hero1);
            Assert.IsFalse(repository.Remove(name2));
        }

        [Test]
        public void Remove_ShouldThrowException_WhenHeroIsNull()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                repository.Remove(null));
            Assert.AreEqual("Name cannot be null (Parameter 'name')", exception.Message);
            Assert.AreEqual("name", exception.ParamName);
        }

        [Test]
        public void GetHeroWithHighestLevel_ShouldReturnTheFirstHeroOfHighestLevel()
        {
            repository.Create(hero1);
            repository.Create(hero2);
            repository.Create(hero3);
            Assert.AreSame(hero2, repository.GetHeroWithHighestLevel());
        }

        [Test]
        public void GetHero_ShouldReturnTheFirstWithThatName()
        {
            repository.Create(hero1);
            repository.Create(hero2);
            Assert.AreSame(hero2, repository.GetHero(name2));
        }

        [Test]
        public void GetHero_ShouldReturnNull_IfHeroIsNotPresent()
        {
            Assert.IsNull(repository.GetHero(name1));
        }
    }
}
namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private readonly string name = "Grommash";
        private readonly int damage = 100;
        private readonly int hp = 200;
        private readonly int minimumHp = 30;
        private Warrior warrior;
        private Warrior opponent;

        [Test]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            warrior = new Warrior(name, damage, hp);
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        [TestCase("\t")]
        [TestCase("\u2000")]
        public void SettingANameThatIsNullOrWhiteSpace_ShouldThrowAnException(string incorrectName)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () =>
                {
                    warrior = new Warrior(incorrectName, damage, hp);
                });
            Assert.AreEqual("Name should not be empty or whitespace!", ex.Message);
        }

        [TestCase(0)]
        [TestCase(-30)]

        public void SettingDamageThatIsNotAPositiveNumber_ShouldThrowAnException(int incorrectDamage)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () =>
                {
                    warrior = new Warrior(name, incorrectDamage, hp);
                });
            Assert.AreEqual("Damage value should be positive!", ex.Message);
        }

        [TestCase(-1)]
        [TestCase(-30)]

        public void SettingHpThatIsANegativeNumber_ShouldThrowAnException(int incorrectHp)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () =>
                {
                    warrior = new Warrior(name, damage, incorrectHp);
                });
            Assert.AreEqual("HP should not be negative!", ex.Message);
        }

        [TestCase(30)]
        [TestCase(29)]
        [TestCase(0)]

        public void AttemptingAnAttackWhenWarriorHPIsAtOrBelow30_ShouldThrowAnException(int incorrectHp)
        {
            warrior = new Warrior(name, damage, incorrectHp);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    warrior.Attack(opponent);
                });
            Assert.AreEqual("Your HP is too low in order to attack other warriors!", ex.Message);
        }

        [TestCase(30)]
        [TestCase(29)]
        [TestCase(0)]

        public void AttemptingAnAttackWhenOpponentHpIsAtOrBelow30_ShouldThrowAnException(int incorrectHp)
        {
            warrior = new Warrior(name, damage, hp);
            opponent = new Warrior("Helscream", 10, incorrectHp);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    warrior.Attack(opponent);
                });
            Assert.AreEqual($"Enemy HP must be greater than {minimumHp} in order to attack him!", ex.Message);
        }

        [Test]

        public void AttemptingAnAttackOnOpponentWhoseDamageIsGreaterThanWarriorHp_ShouldThrowAnException()
        {
            warrior = new Warrior(name, damage, hp);
            opponent = new Warrior("Helscream", 10000000, hp);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    warrior.Attack(opponent);
                });
            Assert.AreEqual($"You are trying to attack too strong enemy", ex.Message);
        }

        [TestCase(10)]
        [TestCase(99)]

        public void AttackingTheOpponent_ShouldReduceWarriorHpCorrectlyByOpponentDamage(int opponentDamage)
        {
            warrior = new Warrior(name, damage, hp);
            opponent = new Warrior("Helscream", opponentDamage, hp);
            warrior.Attack(opponent);
            Assert.AreEqual(hp - opponentDamage, warrior.HP);
        }

        [Test]
        public void AttackingTheOpponent_ShouldReduceOpponentsHPByWarriorDamageCorrectly()
        {
            warrior = new Warrior(name, damage, hp);
            opponent = new Warrior("Helscream", 10, hp);
            warrior.Attack(opponent);
            Assert.AreEqual(hp - warrior.Damage, opponent.HP);
        }

        [TestCase(99)]
        [TestCase(50)]
        public void WhenAttackingOpponent_IfOpponentHP_IsLessThanWarriorDamageOpponentHP_ShouldBeSetToZero(int opponentHp)
        {
            warrior = new Warrior(name, damage, hp);
            opponent = new Warrior("Helscream", damage, opponentHp);
            warrior.Attack(opponent);
            Assert.AreEqual(0, opponent.HP);
        }
    }
}
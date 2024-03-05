using NUnit.Framework;
using NUnit.Framework.Internal;

namespace VendingRetail.Tests
{
    public class CoffeeMattTests
    {
        private CoffeeMat _coffeeMat;
        private int _waterCapacity = 100;
        private int _buttonCount = 2;
        private string _coffee = "coffee";
        private double _coffeePrice = 1;
        private string _tea = "tea";
        private double _teaPrice = 0.5;
        private string _macciato = "macciato";
        private double _macciatoPrice = 1.2;

        [SetUp]
        public void Setup()
        {
            _coffeeMat = new CoffeeMat(_waterCapacity, _buttonCount);
        }

        [Test]
        public void Constructor_ShouldInitializeCoffeeMatt()
        {
            Assert.IsNotNull(_coffeeMat);
        }

        [Test]
        public void Constructor_ShouldSetWaterCapacityCorrectly()
        {
            Assert.AreEqual(_waterCapacity, _coffeeMat.WaterCapacity);
        }

        [Test]
        public void Constructor_ShouldSetButtonCountCorrectly()
        {
            Assert.AreEqual(_buttonCount, _coffeeMat.ButtonsCount);
        }

        [Test]
        public void Constructor_ShouldSetIncomeToZero()
        {
            Assert.AreEqual(0, _coffeeMat.Income);
        }

        [Test]
        public void FillWaterTank_ShouldReturnCorrectMessage_WhenFilledSuccessfully()
        {
            string expectedResult = $"Water tank is filled with {_waterCapacity}ml";
            Assert.AreEqual(expectedResult, _coffeeMat.FillWaterTank());
        }

        [Test]
        public void FillWaterTank_ShouldReturnCorrectMessage_WhenAlreadyFull()
        {
            string expectedResult = $"Water tank is already full!";
            _coffeeMat.FillWaterTank();
            Assert.AreEqual(expectedResult, _coffeeMat.FillWaterTank());
        }

        [Test]
        public void AddDrink_ShouldReturnTrue_WhenSuccessfullyAddingADrink()
        {
            Assert.IsTrue(_coffeeMat.AddDrink(_coffee, _coffeePrice));
            Assert.IsTrue(_coffeeMat.AddDrink(_tea, _teaPrice));
        }

        [Test]
        public void AddDrink_ShouldReturnFalse_WhenAllButtonsAreTaken()
        {
            _coffeeMat.AddDrink(_coffee, _coffeePrice);
            _coffeeMat.AddDrink(_tea, _teaPrice);
            Assert.IsFalse(_coffeeMat.AddDrink(_macciato, _macciatoPrice));
        }

        [Test]
        public void AddDrink_ShouldReturnFalse_WhenDrinkIsAlreadyAdded()
        {
            _coffeeMat.AddDrink(_coffee, _coffeePrice);
            Assert.IsFalse(_coffeeMat.AddDrink(_coffee, _coffeePrice));
        }

        [Test]
        public void BuyDrink_ShouldReturnCorrectString_WhenWaterInTankIsBelow80()
        {
            string expectedResult = "CoffeeMat is out of water!";
            Assert.AreEqual(expectedResult, _coffeeMat.BuyDrink(_coffee));
        }

        [Test]
        public void BuyDrink_ShouldReturnCorrectString_IfDrinkIsNotAvailable()
        {
            _coffeeMat.FillWaterTank();
            string expectedResult = $"{_coffee} is not available!";
            Assert.AreEqual(expectedResult, _coffeeMat.BuyDrink(_coffee));
        }

        [Test]
        public void BuyDrinkSuccessfully_ShouldReduceWaterInTank()
        {
            _coffeeMat.FillWaterTank();
            _coffeeMat.AddDrink(_coffee, _coffeePrice);
            _coffeeMat.BuyDrink(_coffee);
            string expectedResult = "CoffeeMat is out of water!";
            Assert.AreEqual(expectedResult, _coffeeMat.BuyDrink(_coffee));
        }

        [Test]
        public void BuyDrinkSuccessfully_ShouldIncreaseIncome()
        {
            Assert.AreEqual(0, _coffeeMat.Income);
            _coffeeMat.FillWaterTank();
            _coffeeMat.AddDrink(_coffee, _coffeePrice);
            _coffeeMat.BuyDrink(_coffee);
            Assert.AreEqual(_coffeePrice, _coffeeMat.Income);
        }

        [Test]
        public void BuyDrinkSuccessfully_ShouldReturnCorrectString()
        {
            _coffeeMat.FillWaterTank();
            _coffeeMat.AddDrink(_coffee, _coffeePrice);

            string expectedResult = $"Your bill is {_coffeePrice:f2}$";
            Assert.AreEqual(expectedResult, _coffeeMat.BuyDrink(_coffee));
        }

        [Test]
        public void CollectIncome_ShouldSetIncomeToZero()
        {
            _coffeeMat.FillWaterTank();
            _coffeeMat.AddDrink(_coffee, _coffeePrice);
            _coffeeMat.BuyDrink(_coffee);
            _coffeeMat.CollectIncome();

            Assert.AreEqual(0, _coffeeMat.Income);
        }

        [Test]
        public void CollectIncome_ShouldCorrectlyReturnIncomeCollected()
        {
            _coffeeMat.FillWaterTank();
            _coffeeMat.AddDrink(_coffee, _coffeePrice);
            _coffeeMat.BuyDrink(_coffee);

            Assert.AreEqual(_coffeePrice, _coffeeMat.CollectIncome());
        }
    }
}
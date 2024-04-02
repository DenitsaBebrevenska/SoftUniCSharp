using NUnit.Framework;

namespace RepairShop.Tests
{
    public class CarTests
    {
        private Car car;
        private string model = "X";
        private int issuesCount = 2;

        [SetUp]
        public void SetUp()
        {
            car = new Car(model, issuesCount);
        }

        [Test]
        public void Constructor_ShouldInitializeCar()
        {
            Assert.IsNotNull(car);
        }

        [Test]
        public void Constructor_ShouldSetModel()
        {
            Assert.AreEqual(model, car.CarModel);
        }

        [Test]
        public void Constructor_ShouldSetNumberOfIssues()
        {
            Assert.AreEqual(issuesCount, car.NumberOfIssues);
        }

        [Test]
        public void IsFixed_ShouldReturnTrue_WhenNumberOfIssuesIsZero()
        {
            car.NumberOfIssues = 0;
            Assert.IsTrue(car.IsFixed);
        }

        [Test]
        public void IsFixed_ShouldReturnFalse_WhenNumberOfIssuesIsMoreThanZero()
        {
            Assert.IsFalse(car.IsFixed);
        }
    }
}
using INStock.Models;
using Moq;
using NUnit.Framework;

namespace INStock.Tests
{
    public class ProductTests
    {
        private Mock<Product> product;
        private Mock<Product> sameLabelProduct;
        private Mock<Product> product2;
        private Mock<Product> product3;

        [SetUp]
        public void SetUp()
        {
            product = new Mock<Product>("1", 10m, 2);
            sameLabelProduct = new Mock<Product>("1", 20m, 100);
            product2 = new Mock<Product>("2", 10m, 2);
            product3 = new Mock<Product>("0", 10m, 2);
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Assert.IsNotNull(product);
        }


        [Test]
        public void LabelProperty_ShouldReturnCorrectLabel()
        {
            string expectedResult = "1";
            Assert.AreEqual(expectedResult, product.Object.Label);
        }


        [Test]
        public void PriceProperty_ShouldReturnCorrectPrice()
        {
            decimal expectedResult = 10m;
            Assert.AreEqual(expectedResult, product.Object.Price);
        }

        [Test]
        public void QuantityProperty_ShouldReturnCorrectQuantity()
        {
            int expectedResult = 2;
            Assert.AreEqual(expectedResult, product.Object.Quantity);
        }

        [Test]
        public void ComparingTwoProducts_ShouldWorkCorrectly()
        {
            Assert.That(0 == product.Object.CompareTo(sameLabelProduct.Object));
            Assert.That(0 > product.Object.CompareTo(product2.Object));
            Assert.That(0 < product.Object.CompareTo(product3.Object));
        }
    }
}

using INStock.Exceptions;
using INStock.Models;
using INStock.Models.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace INStock.Tests
{
    public class ProductStockTests
    {
        private IProductStock stock;
        private Mock<Product> product;
        private Mock<Product> product2;
        private Mock<Product> product3;

        [SetUp]
        public void SetUp()
        {
            stock = new Stock();
            product = new Mock<Product>("1", 10m, 2);
            product2 = new Mock<Product>("2", 50m, 10);
            product3 = new Mock<Product>("3", 100m, 2);
        }

        [Test]
        public void Constructor_ShouldInitializeTheStock()
        {
            Assert.That(stock, Is.Not.Null);
        }

        [Test]
        public void AddingAProduct_ShouldWorkCorrectly()
        {
            stock.Add(product.Object);
            Assert.That(stock.Contains(product.Object));
        }


        [Test]
        public void CheckingIfStockContainsAProduct_ShouldWorkCorrectly()
        {
            Assert.IsFalse(stock.Contains(product.Object));
            stock.Add(product.Object);
            Assert.IsTrue(stock.Contains(product.Object));
        }

        [Test]
        public void Count_ShouldReturnCorrectly()
        {
            Assert.AreEqual(0, stock.Count);
            stock.Add(product.Object);
            Assert.AreEqual(1, stock.Count);
        }

        [Test]
        public void RemoveItem_ShouldWorkCorrectly()
        {
            Assert.IsFalse(stock.Remove(product.Object));
            Assert.AreEqual(0, stock.Count);
            stock.Add(product.Object);
            Assert.AreEqual(1, stock.Count);
            Assert.IsTrue(stock.Remove(product.Object));
            Assert.AreEqual(0, stock.Count);
        }

        [Test]
        public void FindNthProduct_ShouldWorkCorrectly()
        {
            stock.Add(product.Object);
            stock.Add(product2.Object);
            stock.Add(product3.Object);
            Assert.AreSame(product.Object, stock.Find(0));
            Assert.AreSame(product2.Object, stock.Find(1));
            Assert.AreSame(product3.Object, stock.Find(2));
        }

        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(100)]
        public void FindNthProduct_ShouldThrowException_WhenGivenInvalidIndex(int invalidIndex)
        {
            stock.Add(product.Object);
            stock.Add(product2.Object);
            stock.Add(product3.Object);
            Assert.Throws<InvalidIndexException>(
                () =>
                {
                    stock.Find(invalidIndex);
                });
        }

        [Test]
        public void FindByLabel_ShouldWorkCorrectly()
        {
            stock.Add(product.Object);
            stock.Add(product2.Object);
            Assert.AreSame(product.Object, stock.FindByLabel(product.Object.Label));
            Assert.AreSame(product2.Object, stock.FindByLabel(product2.Object.Label));
        }

        [TestCase("000")]
        [TestCase("3")]
        public void FindByLabel_ShouldThrowException_WhenNoProductByThatLabelIsFound(string wrongLabel)
        {
            stock.Add(product.Object);
            stock.Add(product2.Object);
            Assert.Throws<NonExistentProductInStockException>(
                () =>
                {
                    stock.FindByLabel(wrongLabel);
                });
        }

        [Test]
        public void FindAllInRange_ShouldReturnRangeCorrectly()
        {
            stock.Add(product.Object);
            stock.Add(product.Object);
            stock.Add(product2.Object);
            stock.Add(product3.Object);

            List<IProduct> expectedResult = new List<IProduct>()
            {
                product2.Object,
                product.Object,
                product.Object
            };

            CollectionAssert.AreEqual(expectedResult, stock.FindAllInRangeAll(10, 50));
        }

        [Test]
        public void FindAllInRange_ShouldReturnEmptyCollection_WhenNoProductsAreInRange()
        {
            IEnumerable<IProduct> products = stock.FindAllInRangeAll(10, 50);
            Assert.That(products, Is.Empty);
        }

        [Test]
        public void FindAllByPrice_ShouldReturnCorrectly()
        {
            Mock<Product> product4 = new Mock<Product>("4", 100m, 2);
            stock.Add(product.Object);
            stock.Add(product2.Object);
            stock.Add(product3.Object);
            stock.Add(product4.Object);

            List<IProduct> expectedResult = new List<IProduct>()
            {
                product3.Object,
                product4.Object
            };

            CollectionAssert.AreEqual(expectedResult, stock.FindAllByPrice(100));
        }

        [Test]
        public void FindAllByPrice_ShouldReturnEmptyCollection_WhenNoProductsAreFound()
        {
            stock.Add(product.Object);
            stock.Add(product.Object);
            stock.Add(product2.Object);
            stock.Add(product3.Object);

            IEnumerable<IProduct> products = stock.FindAllByPrice(200);
            Assert.That(products, Is.Empty);
        }

        [Test]
        public void FindMostExpensiveProduct_ShouldReturnCorrectly()
        {
            stock.Add(product.Object);
            stock.Add(product2.Object);
            stock.Add(product3.Object);

            Assert.AreEqual(product3.Object, stock.FindMostExpensiveProduct());
        }

        [Test]
        public void FindMostExpensiveProduct_ShouldReturnNull_WhenNoProductIsFound()
        {
            Assert.That(stock.FindMostExpensiveProduct(), Is.Null);
        }

        [Test]
        public void FindAllByQuantity_ShouldReturnCorrectly()
        {
            stock.Add(product.Object);
            stock.Add(product2.Object);
            stock.Add(product3.Object);

            List<IProduct> expectedResult = new List<IProduct>()
            {
                product.Object,
                product3.Object
            };

            CollectionAssert.AreEqual(expectedResult, stock.FindAllByQuantity(2));
        }

        [Test]
        public void FindAllByQuantity_ShouldReturnEmptyCollection_WhenNoProductsAreFound()
        {
            stock.Add(product.Object);
            stock.Add(product2.Object);
            stock.Add(product3.Object);

            IEnumerable<IProduct> products = stock.FindAllByQuantity(200);
            Assert.That(products, Is.Empty);
        }

        [Test]
        public void StockCollection_ShouldBeForeachedCorrectly()
        {
            stock.Add(product.Object);
            stock.Add(product2.Object);
            stock.Add(product3.Object);

            List<IProduct> products = new List<IProduct>();

            foreach (var currentProduct in stock)
            {
                products.Add(currentProduct);
            }

            CollectionAssert.AreEqual(stock, products);
        }
    }
}

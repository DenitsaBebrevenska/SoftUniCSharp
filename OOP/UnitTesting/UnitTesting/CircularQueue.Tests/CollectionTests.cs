namespace Collections.Tests
{
    public class CollectionTests
    {
        private Collection<int> collection;
        private int[] numbers5 = Enumerable.Range(1, 5).ToArray();

        [Test]
        public void Constructor_ShouldInitializeInnerArray()
        {
            collection = new Collection<int>();
            Assert.IsNotNull(collection);
        }

        [Test]
        public void CountProperty_ShouldReturnCorrectCount()
        {
            collection = new Collection<int>(numbers5);
            Assert.AreEqual(numbers5.Length, collection.Count);
        }

        [Test]
        public void Capacity_ShouldBeMoreThanTheCountOfNumbersUponInitialization()
        {
            collection = new Collection<int>(numbers5);
            Assert.That(collection.Capacity > collection.Count);
        }

        [Test]
        public void AddingAnItem_ShouldAddItToTheCollection()
        {
            collection = new Collection<int>();
            collection.Add(1);
            Assert.AreEqual(1, collection[0]);

        }

        [Test]
        public void AddingAnItem_ShouldCorrectlyIncreaseCount()
        {
            collection = new Collection<int>();
            collection.Add(1);
            Assert.AreEqual(1, collection.Count);
        }

        [Test]
        public void AddRange_ShouldAddItemsInRangeToTheCollection()
        {
            collection = new Collection<int>();
            collection.AddRange(numbers5);
            string expectedResult = $"[{string.Join(", ", numbers5)}]";
            Assert.AreEqual(expectedResult, collection.ToString());

        }

        [Test]
        public void AddingRange_ShouldCorrectlyIncreaseCount()
        {
            collection = new Collection<int>();
            collection.AddRange(numbers5);
            Assert.AreEqual(numbers5.Length, collection.Count);
        }

        [Test]
        public void AddingOneElementPastCurrentCapacity_ShouldGrowTheCapacity()
        {
            int[] elements8 = Enumerable.Range(1, 8).ToArray();
            collection = new Collection<int>(elements8); //Capacity is at 16 
            collection.AddRange(elements8); //Capacity is at 16
            Assert.AreEqual(collection.Capacity, collection.Count);
            collection.Add(9);
            Assert.That(collection.Capacity > collection.Count);
        }

        [Test]
        public void AddingElementsPastCurrentCapacity_ShouldGrowTheCapacity()
        {
            int[] elements8 = Enumerable.Range(1, 8).ToArray();
            collection = new Collection<int>(elements8); //Capacity is at 16 
            collection.AddRange(elements8); //Capacity is at 16
            Assert.AreEqual(collection.Capacity, collection.Count);
            collection.AddRange(elements8);
            Assert.That(collection.Capacity > collection.Count);
        }

        [Test]
        public void Index_ShouldCorrectlyReturnElementAtThatIndex()
        {
            collection = new Collection<int>();
            collection.Add(1);
            Assert.AreEqual(1, collection[0]);
        }

        [Test]
        public void Index_ShouldCorrectlySetElementAtThatIndex()
        {
            collection = new Collection<int>();
            collection.Add(1);
            collection[0] = 100;
            Assert.AreEqual(100, collection[0]);
        }

        [Test]
        public void TryingToGetIndexAtInvalidIndex_ShouldThrowException()
        {
            collection = new Collection<int>(1);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    int result = collection[10];
                });
        }

        [Test]
        public void TryingToSetIndexAtInvalidIndex_ShouldThrowException()
        {
            collection = new Collection<int>(1);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    collection[10] = 10;
                });
        }

        [Test]
        public void InsertingAtGivenIndex_ShouldWorkCorrectly()
        {
            collection = new Collection<int>(numbers5);
            collection.InsertAt(0, 100);
            Assert.AreEqual(100, collection[0]);
            string expectedResult = $"[100, {string.Join(", ", numbers5)}]";
            Assert.AreEqual(expectedResult, collection.ToString());
        }

        [Test]
        public void Inserting_ShouldCorrectlyIncreaseCount()
        {
            collection = new Collection<int>(numbers5);
            collection.InsertAt(0, 100);
            Assert.AreEqual(numbers5.Length + 1, collection.Count);
        }

        [Test]
        public void TryingToInsertAtInvalidIndex_ShouldThrowException()
        {
            collection = new Collection<int>(1);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    collection.InsertAt(10, 10);
                });
        }

        [Test]
        public void ExchangingTwoElements_ShouldWorkCorrectly()
        {
            collection = new Collection<int>(numbers5);
            collection.Exchange(0, 4);
            string expectedResult = $"[5, 2, 3, 4, 1]";
            Assert.AreEqual(expectedResult, collection.ToString());
        }

        [Test]
        public void TryingToExchangeTwoElements_WhenFirstIndexIsInvalid_ShouldThrowException()
        {
            collection = new Collection<int>(numbers5);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    collection.Exchange(20, 0);
                });
        }

        [Test]
        public void TryingToExchangeTwoElements_WhenSecondIndexIsInvalid_ShouldThrowException()
        {
            collection = new Collection<int>(numbers5);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    collection.Exchange(0, 20);
                });
        }

        [Test]
        public void TryingToExchangeTwoElements_WhenBothIndecesAreInvalid_ShouldThrowException()
        {
            collection = new Collection<int>(numbers5);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    collection.Exchange(20, 30);
                });
        }

        [Test]
        public void RemovingAtGivenIndex_ShouldWorkCorrectly()
        {
            collection = new Collection<int>(numbers5);
            int removed = collection.RemoveAt(0);
            Assert.AreEqual(numbers5[0], removed);
            string expectedResult = $"[2, 3, 4, 5]";
            Assert.AreEqual(expectedResult, collection.ToString());
        }

        [Test]
        public void RemovingAtIndex_ShouldCorrectlyIncreaseCount()
        {
            collection = new Collection<int>(numbers5);
            collection.RemoveAt(0);
            Assert.AreEqual(numbers5.Length - 1, collection.Count);
        }

        [Test]
        public void TryingToRemoveAtInvalidIndex_ShouldThrowException()
        {
            collection = new Collection<int>(1);
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    collection.RemoveAt(10);
                });
        }

        [Test]
        public void Clear_ShouldSetCountToZero()
        {
            collection = new Collection<int>(numbers5);
            collection.Clear();
            Assert.AreEqual(0, collection.Count);
        }

        [Test]
        public void ToString_ShouldWorkCorrectly()
        {
            collection = new Collection<int>(numbers5);
            Assert.AreEqual($"[{string.Join(", ", numbers5)}]", collection.ToString());
        }

        [Test]
        public void ToString_ShouldWorkCorrectlyWithEmptyCollection()
        {
            collection = new Collection<int>();
            Assert.AreEqual($"[]", collection.ToString());
        }

        [Test]
        [Timeout(500)]
        public void Test100_000Times()
        {
            const int iterationCount = 1_000;
            collection = new Collection<int>();
            int addedElements = 0, removedElements = 0, counter = 0;

            for (int i = 0; i < iterationCount; i++)
            {
                collection.Add(++counter);
                collection.Add(++counter);
                addedElements += 2;

                collection.AddRange(++counter, ++counter);
                addedElements += 2;

                collection.RemoveAt(0);
                collection.RemoveAt(0);
                removedElements += 2;

                collection.Exchange(0, 1);
                collection.Exchange(0, 1);

                collection.InsertAt(0, ++counter);
                collection.InsertAt(1, ++counter);
                addedElements += 2;

                collection.RemoveAt(0);
                collection.RemoveAt(1);
                removedElements += 2;
            }

            Assert.AreEqual(addedElements - removedElements, collection.Count);
        }
    }
}
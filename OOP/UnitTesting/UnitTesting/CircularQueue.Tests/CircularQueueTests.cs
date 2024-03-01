namespace Collections.Tests
{
    public class CircularQueueTests
    {
        private CircularQueue<int> queue;

        [Test]
        public void DefaultConstructor_ShouldWorkCorrectly()
        {
            queue = new CircularQueue<int>();
            Assert.IsNotNull(queue);
            Assert.AreEqual("[]", queue.ToString());
            Assert.That(queue.Capacity > 0);
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(0, queue.StartIndex);
            Assert.AreEqual(0, queue.EndIndex);
        }

        [TestCase(10)]
        [TestCase(20)]
        public void ConstructorThatAcceptsCapacity_ShouldWorkCorrectly(int capacity)
        {
            queue = new CircularQueue<int>(capacity);
            Assert.IsNotNull(queue);
            Assert.AreEqual("[]", queue.ToString());
            Assert.AreEqual(capacity, queue.Capacity);
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(0, queue.StartIndex);
            Assert.AreEqual(0, queue.EndIndex);
        }

        [Test]
        public void Enqueue_ShouldCorrectlyEnqueueAnElement()
        {
            queue = new CircularQueue<int>();
            queue.Enqueue(1);

            Assert.AreEqual("[1]", queue.ToString());
        }

        [Test]
        public void Enqueue_ShouldCorrectlyIncreaseCount()
        {
            queue = new CircularQueue<int>();
            queue.Enqueue(1);

            Assert.AreEqual(1, queue.Count);
        }

        [Test]
        public void Enqueue_ShouldCorrectlyUpdateEndIndex()
        {
            queue = new CircularQueue<int>();
            queue.Enqueue(1);

            Assert.AreEqual(1, queue.EndIndex);
        }


        [Test]
        public void EnqueueOnFullCapacity_ShouldCauseTheCollectionToGrow()
        {
            queue = new CircularQueue<int>(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.That(queue.Capacity > 2);
        }

        [Test]
        public void DequeueOnEmptyCollection_ShouldThrowAnException()
        {
            queue = new CircularQueue<int>();
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    queue.Dequeue();
                });

            Assert.AreEqual("The queue is empty!", exception.Message);
        }

        [Test]
        public void Dequeue_ShouldCorrectlyRemoveFirstElement()
        {
            queue = new CircularQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();
            Assert.AreEqual("[2, 3]", queue.ToString());
        }

        [Test]
        public void Dequeue_ShouldCorrectlyUpdateStartIndex()
        {
            queue = new CircularQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();
            Assert.AreEqual(1, queue.StartIndex);
        }

        [Test]
        public void Dequeue_ShouldCorrectlyDecreaseCount()
        {
            queue = new CircularQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();
            Assert.AreEqual(2, queue.Count);
        }

        [Test]
        public void PeekOnEmptyCollection_ShouldThrowAnException()
        {
            queue = new CircularQueue<int>();
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    queue.Peek();
                });

            Assert.AreEqual("The queue is empty!", exception.Message);
        }

        [Test]
        public void Peek_ShouldCorrectlyExposeFirstElement()
        {
            queue = new CircularQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual(1, queue.Peek());
        }

        [Test]
        public void CallingToString_ShouldShowCorrectRepresentationOfTheCollection()
        {
            queue = new CircularQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual("[1, 2]", queue.ToString());
        }

        [Test]
        public void CallingToArray_ShouldReturnCorrectArray()
        {
            queue = new CircularQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual(new int[] { 1, 2 }, queue.ToArray());
        }

        [Test]
        public void GrowingTheCollection_ShouldCorrectlySetStartingIndex()
        {
            queue = new CircularQueue<int>(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue(); //this changes startIndex to 1
            queue.Enqueue(3);
            queue.Enqueue(4); //Growing the collection which should make the startIndex 0 now

            Assert.AreEqual(0, queue.StartIndex);
        }

        [Test]
        public void GrowingTheCollection_ShouldCorrectlySetEndIndex()
        {
            queue = new CircularQueue<int>(2);
            queue.Enqueue(1); //End index is 1
            queue.Enqueue(2); //End index is 2
            queue.Enqueue(3); //Growing the collection, End index should be 3

            Assert.AreEqual(3, queue.EndIndex);
        }

        [Test]
        public void CrossingStartAndIndex_ShouldWorkCorrectly()
        {
            queue = new CircularQueue<int>(3);
            queue.Enqueue(1); //End index is 1, start index is 0
            queue.Enqueue(2); //End index is 2, start index is 0
            queue.Enqueue(3); //End index is 0, start index is 0
            queue.Dequeue(); //End index is 0, start index - 1

            Assert.That(queue.EndIndex < queue.StartIndex);
        }


        [Test]
        public void MultipleOperationsOnCollections_ShouldWorkCorrectly()
        {
            const int initialCapacity = 2;
            const int iterationCount = 300;
            queue = new CircularQueue<int>(initialCapacity);
            int addedElements = 0, removedElements = 0, counter = 0;

            for (int i = 0; i < iterationCount; i++)
            {
                Assert.That(queue.Count == addedElements - removedElements);
                queue.Enqueue(++counter);
                queue.Enqueue(++counter);
                addedElements += 2;
                Assert.That(queue.Count == addedElements - removedElements);
                Assert.AreEqual(removedElements + 1, queue.Peek());

                int removedElement = queue.Dequeue();
                removedElements++;
                Assert.AreEqual(removedElements, removedElement);
                Assert.AreEqual(addedElements - removedElements, queue.Count);

                var expectedElements = Enumerable.Range(removedElements + 1, addedElements - removedElements).ToArray();
                var expectedString = "[" + string.Join(", ", expectedElements) + "]";
                var queueAsArray = queue.ToArray();
                var queueAsString = queue.ToString();

                CollectionAssert.AreEqual(expectedElements, queueAsArray);
                Assert.AreEqual(expectedString, queueAsString);
                Assert.That(queue.Capacity >= queue.Count);
            }

            Assert.That(queue.Capacity > initialCapacity);
        }

        [Test]
        [Timeout(500)]
        public void Test1MillionTimes()
        {
            const int iterationCount = 1_000_000;
            queue = new CircularQueue<int>();
            int addedElements = 0, removedElements = 0, counter = 0;

            for (int i = 0; i < iterationCount; i++)
            {
                queue.Enqueue(++counter);
                queue.Enqueue(++counter);
                addedElements += 2;

                queue.Dequeue();
                removedElements++;
            }

            Assert.AreEqual(addedElements - removedElements, queue.Count);
        }
    }
}
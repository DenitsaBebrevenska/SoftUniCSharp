namespace CustomDataStructuresExercise
{
    public class CustomQueue
    {
        //•	void Enqueue(int element) – Adds the given element to the queue
        // •	int Dequeue() – Removes the first element
        // •	int Peek() – Returns the first element in the queue without removing it
        // •	void Clear() – Delete all elements in the queue
        // •	void ForEach(Action<int> action) – Goes through each of the elements in the queue

        private const int InitialCapacity = 4;
        private int[] items;

        public int Count { get; private set; }

        public CustomQueue()
        {
            items = new int[InitialCapacity];
            Count = 0;
        }
        private void ThrowInvalidOperationException()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
        private void Resize()
        {
            int[] newArray = new int[items.Length * 2];
            items.CopyTo( newArray, 0 );
            items = newArray;
        }
        private void ShiftLeft()
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = items[i + 1];
            }
        }

        private void Shrink()
        {
            int[] newArray = new int[items.Length / 2];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = items[i];
            }

            items = newArray;
        }

        public void Enqueue(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = element;
            Count++;
        }

        public int Dequeue()
        {
            ThrowInvalidOperationException();

            int elementToDequeue = items[0];
            Count--;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            ShiftLeft();

            items[Count] = default; //not a must, but a preference to return to default value
            return elementToDequeue;
        }
        public int Peek()
        {
            ThrowInvalidOperationException();

            return items[0];
        }

        public void Clear()
        {
            Count = 0;
            items = new int[InitialCapacity];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
    }
}

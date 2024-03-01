namespace CustomDataStructuresExercise
{
    public class CustomStack
    {
        //•	void Push(int element) – Adds the given element to the stack
        // •	int Pop() – Removes the last added element
        // •	int Peek() – Returns the last element in the stack without removing it
        // •	void ForEach(Action<int> action) – Goes through each of the elements in the stack
        
        private const int InitialCapacity = 4;
        private int[] items;

        public int Count { get; private set; }
        

        public CustomStack()
        {
            items = new int[InitialCapacity];
            Count = 0;
        }

        private void ThrowInvalidOperationException()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
        private void Resize()
        {
            int[] newArray = new int[items.Length * 2];
            items.CopyTo( newArray, 0 );
            items = newArray;
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

        public void Push(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = element;
            Count++;
        }

        public int Pop()
        {
            ThrowInvalidOperationException();

            int numberToPop = items[Count - 1];
            items[Count - 1] = default; // not necessary but I prefer set the value back to default
            Count--;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return numberToPop;
        }

        public int Peek()
        {
            ThrowInvalidOperationException();
            return items[Count - 1];
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

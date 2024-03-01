namespace CustomDataStructuresExercise
{
    //•	void Add(int element) – Adds the given element to the end of the list
    // •	int RemoveAt(int index) – Removes the element at the given index
    // •	bool Contains(int element) - Checks if the list contains the given element returns (True or False)
    // •	void Swap(int firstIndex, int secondIndex) - Swaps the elements at the given indexes

    //•	Resize – this method will be used to increase the internal collection's length twice.
    // •	Shrink – this method will help us to decrease the internal collection's length twice.
    // •	Shift – this method will help us to rearrange the internal collection's elements after removing one.

    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;
        public int Count { get; private set; }

        public CustomList()
        {
            items = new int[InitialCapacity];
        }

        public int this[int index]
        {
            get
            {
                ThrowOutOfRangeException(index);
                return items[index];
            }
            set
            {
                ThrowOutOfRangeException(index);
                items[index] = value;
            }
        }

        private void ThrowOutOfRangeException(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index item");
            }
        }

        
        private void Resize()
        {
            int[] resizedArray = new int[items.Length * 2];

            items.CopyTo(resizedArray, 0 );
            items = resizedArray;
        }

        private void Shrink()
        {
            int[] resizedArray = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                resizedArray[i] = items[i];
            }

            items = resizedArray;
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count] = default; //that is not necessary but I prefer to reset the item
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count - 1; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }

        public void Add(int item)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = item;
            Count++;
        }

        public int RemoveAt(int index)
        {
            ThrowOutOfRangeException(index);

            int numberToReturn = items[index];

            ShiftToLeft(index);
            Count--;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return numberToReturn;
        }

        public void InsertAt(int index, int item)
        {
            if (index < 0 || index > Count) //the exception is different than the rest because we can insert in the end
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (Count == items.Length)
            {
                Resize();
            }

            Count++;
            ShiftToRight(index);
            items[index] = item;
        }

        public void AddRange(int[] itemsToAdd)
        {
            if (Count + itemsToAdd.Length >= items.Length)
            {
                Resize();
            }

            foreach (var item in itemsToAdd)
            {
                items[Count++] = item;
            }
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == item)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ThrowOutOfRangeException(firstIndex);
            ThrowOutOfRangeException(secondIndex);

            (items[firstIndex], items[secondIndex]) = (items[secondIndex], items[firstIndex]);
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }

        public void PrintList()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write(items[i] + " ");
            }

            Console.WriteLine();
        }
        public int Find(Predicate<int> findPredicate)
        {
            int result = default;

            for (int i = 0; i < Count; i++)
            {
                if (findPredicate(items[i]))
                {
                    result = items[i];
                    break;
                }
            }
            return result;
        }

        public void Reverse()
        {
            int[] tempArray = new int[Count];
            int index = 0;

            for (int i = Count - 1; i >= 0; i--, index++)
            {
                tempArray[i] = items[index];
            }

            for (int i = 0; i < Count; i++)
            {
                items[i] = tempArray[i];
            }
        }
    }
}

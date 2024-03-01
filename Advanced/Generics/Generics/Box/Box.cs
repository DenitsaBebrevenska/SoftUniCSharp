namespace BoxOfT
{
    public class Box<T>
    {
        private T[] internalArray = new T[30]; //any capacity since it is just for testing out generics
        private int count;
        public int Count 
        {
            get { return count; }
        }

        public void Add(T element)
        {
            internalArray[count] = element;
            count++;

        }

        public T Remove()
        {
            T itemToRemove = internalArray[count - 1];
            internalArray[count - 1] = default;
            count--;

            return itemToRemove;
        }
    }
}

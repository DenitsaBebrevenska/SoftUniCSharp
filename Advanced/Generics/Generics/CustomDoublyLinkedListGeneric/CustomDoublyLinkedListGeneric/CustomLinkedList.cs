using System.Collections;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> _head;
        private ListNode<T> _tail;
        public int Count { get; private set; }
        
        public void AddFirst(T element)
        {
            ListNode<T> newNode = new ListNode<T>(element);

            if (Count == 0)
            {
                _head = _tail = newNode;
            }
            else
            { 
                newNode.Next = _head;
                _head.Previous = newNode;
                _head = newNode;
            }

            Count++;
        }

        public void AddLast(T element)
        {
            ListNode<T> newNode = new ListNode<T>(element);

            if (Count == 0)
            {
                _head = _tail = newNode;
            }
            else
            {
                newNode.Previous = _tail;
                _tail.Next = newNode;
                _tail = newNode;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var returnValue = _head.Value;
            _head = _head.Next;

            if (_head != null)
            {
                _head.Previous = null;
            }
            else
            {
                _tail = null;
            }

            Count --;
            return returnValue;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var returnValue = _tail.Value;
            _tail = _tail.Previous;

            if (_tail != null)
            {
                _tail.Next = null;
            }
            else
            {
                _head = null;
                
            }

            Count --;
            return returnValue;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentNode = _head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            ListNode<T> currentNode = _head;
            int index = 0;

            while (currentNode != null)
            {
                array[index++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currentNode = _head;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

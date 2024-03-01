namespace CustomDoublyLinkedList
{
    public class CustomLinkedList
    {
        private Node head { get; set; }
        private Node tail { get; set; }
        public int Count { get; private set; }
        
        public void AddFirst(int value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = tail = newNode;
            }
            else
            { 
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }

            Count++;
        }

        public void AddLast(int value)
        {
            Node newNode = new Node(value);

            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }

            Count++;
        }

        public int RemoveFirst()
        {
            if (head == null)
            {
                throw new NullReferenceException("List is empty");
            }

            Node nodeToRemove = head;

            if (head.Next == null)
            {
                head = tail = null;
            }
            else
            {
                head = nodeToRemove.Next;
                nodeToRemove.Next = null;
                head.Previous = null;
            }

            Count --;
            return nodeToRemove.Value;
        }

        public int RemoveLast()
        {
            if (tail == null)
            {
                throw new NullReferenceException("List is empty");
            }

            Node nodeToRemove = tail;

            if (tail.Previous == null)
            {
                head = tail = null;
            }
            else
            {
                tail = nodeToRemove.Previous;
                nodeToRemove.Previous = null;
                tail.Next = null;
            }

            Count --;
            return nodeToRemove.Value;
        }

        public void ForEach(Action<int> action)
        {
            Node currentNode = head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            Node currentNode = head;
            int index = 0;

            while (currentNode != null)
            {
                array[index++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return array;
        }
    }
}

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddLast(4);
            list.AddLast(5);
            // 1 2 3 4 5 
            Console.WriteLine(list.RemoveFirst()); // 1
            Console.WriteLine(list.RemoveLast()); // 5

            foreach (int number in list)
            {
                Console.WriteLine(number);
            }
        }
    }
}

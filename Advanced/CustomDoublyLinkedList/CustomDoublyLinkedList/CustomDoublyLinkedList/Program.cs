namespace CustomDoublyLinkedList
{
    internal class Program
    {
        static void Main()
        {
           //The custom doubly linked list will work only with integers. It will have the following functionalities: 
           // •	void AddFirst(int element) – adds an element at the beginning of the collection
           // •	void AddLast(int element) – adds an element at the end of the collection
           // •	int RemoveFirst() – removes the element at the beginning of the collection
           // •	int RemoveLast() – removes the element at the end of the collection
           // •	void ForEach() – goes through the collection and executes a given action
           // •	int[] ToArray() – returns the collection as an array
           //
           CustomLinkedList list = new CustomLinkedList();
           list.AddFirst(1);
           list.AddFirst(2);
           list.AddFirst(3);
           list.AddLast(-1);
           list.AddLast(-2);
           list.AddLast(-3);
           //3 2 1 -1 -2 -3
           Console.WriteLine(list.RemoveFirst());
           //2 1 -1 -2 -3
           Console.WriteLine(list.RemoveLast());
           //2 1 -1 -2
           list.ForEach(n => Console.WriteLine(n));
           //4
           Console.WriteLine(list.Count);
           int[] array = list.ToArray();
           Console.WriteLine(string.Join(' ', array));
        }
    }
}

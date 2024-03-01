namespace CustomDataStructuresExercise
{
    public class Program
    {
        //Data structures just for integers for now
        static void Main()
        {
            //queue
            CustomQueue queue = new CustomQueue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            // 1 2 3 4
            int n = queue.Dequeue(); 
            //2 3 4
            Console.WriteLine(n); // 1
            queue.Enqueue(5);
            // 2 3 4 5
            queue.ForEach(n => Console.WriteLine(n));
            Console.WriteLine(queue.Peek()); // 2
            queue.Clear();

            //stack
            CustomStack stack = new CustomStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            // 1 2 3 4 
            int m = stack.Pop(); // 4
            // 1 2 3
            Console.WriteLine(m);
            Console.WriteLine(stack.Peek()); //3
            stack.ForEach(n => Console.WriteLine(n));

            //list
            CustomList list = new();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.PrintList();
            //1 2 3 4 5
            Console.WriteLine($"Count:{list.Count}"); // 5
            Console.WriteLine($"Removed: {list.RemoveAt(0)}"); //1
            list.PrintList();
            //2 3 4 5
            Console.WriteLine($"Count:{list.Count}"); //4
            Console.WriteLine($"Removed: {list.RemoveAt(0)}"); //2
            list.PrintList();
            //3 4 5
            Console.WriteLine($"Count:{list.Count}"); //3
            list.InsertAt(1, 7);
            list.PrintList();
            //3 7 4 5
            list.InsertAt(0, 100);
            list.PrintList();
            //100 3 7 4 5
            list.InsertAt(5, 99);
            list.PrintList();
            //100 3 7 4 5 99
            Console.WriteLine(list.Contains(99)); //true
            Console.WriteLine(list.Contains(0)); //false
            list.Swap(0, 5);
            list.PrintList();
            //99 3 7 4 5 100
            list.ForEach(n => Console.WriteLine(n));
            int x = list.Find(x => x % 2 == 0);
            Console.WriteLine(x); //4
            list.Reverse();
            list.PrintList();
            //100 5 4 7 3 99
            Console.WriteLine(list[0]);
            list[0] = 1;
            Console.WriteLine(list[0]);
            //1 5 4 7 3 99
            list.AddRange(new int[]{11,22,33});
            //1 5 4 7 3 99 11 22 33
        }
    }
    }

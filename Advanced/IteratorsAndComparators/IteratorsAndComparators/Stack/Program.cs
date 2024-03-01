namespace Stack
{
    internal class Program
    {
        static void Main()
        {
            CustomStack<int> stack = new CustomStack<int>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command.Contains("Push"))
                {
                    string[] commandArgs = command.Split("Push ");
                    List<int> itemsToPush = commandArgs[1].Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
                    stack.Push(itemsToPush);
                }
                else //Pop
                {
                    stack.Pop();
                }
            }

            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

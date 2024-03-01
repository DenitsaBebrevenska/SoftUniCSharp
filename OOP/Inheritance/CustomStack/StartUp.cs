namespace CustomStack
{
    public class StartUp
    {
        static void Main()
        {
            StackOfStrings stack = new();

            Console.WriteLine(stack.IsEmpty());

            Stack<string> addition = new();

            for (int i = 0; i < 5; i++)
            {
                addition.Push(i.ToString());
            }

            stack.AddRange(addition);

        }
    }
}

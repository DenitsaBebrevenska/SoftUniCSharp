namespace SimpleRecursion
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            Print(n, text);
        }

        static void Print(int n, string text)
        {
            if (n == 0) //define recursion floor
            {
                return;
            }

            Console.WriteLine(text);
            Print(--n, text);
        }
    }
}

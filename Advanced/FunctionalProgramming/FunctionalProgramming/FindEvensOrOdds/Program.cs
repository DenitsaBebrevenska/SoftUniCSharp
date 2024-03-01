namespace FindEvensOrOdds
{
    internal class Program
    {
        static void Main()
        {
            //You are given a lower and an upper bound for a range of integer numbers. Then a command specifies if you need to list all even or odd numbers in the given range. Use Predicate<T>.
            int[] numberRange = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string filterType = Console.ReadLine();
            Predicate<int> isEven = x => x % 2 == 0;
            
            for (int i = numberRange[0]; i <= numberRange[1]; i++)
            {
                if (filterType == "even" && isEven(i))
                {
                    Console.Write(i + " ");
                }
                else if (filterType == "odd" && !isEven(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}

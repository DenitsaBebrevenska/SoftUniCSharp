namespace ListOfPredicates
{
    internal class Program
    {
        static void Main()
        {
            //Find all numbers in the range 1…N that are divisible by the numbers of a given sequence. On the first line, you will be given an integer N – which is the end of the range. On the second line, you will be given a sequence of integers which are the dividers. Use predicates/functions.

            int endRange = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], bool> isDivisibleByAll = (number, dividerNumbers) =>
            {
                foreach (int divider in dividerNumbers)
                {
                    if (number % divider != 0)
                    {
                        return false;
                    }
                }

                return true;
            };

            Action<int[]> printDivisibleNumbers = dividers =>
            {
                for (int i = 1; i <= endRange; i++)
                {
                    if (isDivisibleByAll(i, dividers))
                    {
                        Console.Write(i + " ");
                    }
                }
            };

            printDivisibleNumbers(dividers);
        }
    }
}

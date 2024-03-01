namespace Quicksort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sort an array of elements using the famous quicksort.
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Quick.Sort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

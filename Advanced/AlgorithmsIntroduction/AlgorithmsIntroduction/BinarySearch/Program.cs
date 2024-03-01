namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int key = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch.IndexOf(numbers, key));

        }
    }
}

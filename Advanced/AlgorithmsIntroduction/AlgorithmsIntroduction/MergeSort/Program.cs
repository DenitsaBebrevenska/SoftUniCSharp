namespace MergeSortAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sort an array of elements using the famous merge sort.
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] sortedNumbers = Mergesort<int>.MergeSort(numbers);
            Console.WriteLine(string.Join(' ', sortedNumbers));
        }
    }

}

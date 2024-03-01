namespace CustomComparator
{
    public class Program
    {
        static void Main()
        {
            //Write a custom comparator that sorts all even numbers before all the odd ones in ascending order.
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            CustomNumberComparator comparator = new CustomNumberComparator();

            Array.Sort(array, comparator);

            Console.WriteLine(string.Join(" ", array));
            
        }
    }
}

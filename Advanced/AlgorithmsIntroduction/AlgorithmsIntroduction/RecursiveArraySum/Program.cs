namespace RecursiveArraySum
{
    internal class Program
    {
        static void Main()
        {
            //Create a program that sums all elements in an array. Use recursion.
            List<int> integers = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Console.WriteLine(CalculateSum(integers, integers.Count - 1));
        }

        private static int CalculateSum(List<int> integers, int index)
        {
            if (index == 0)
            {
                return integers[0];
            }

            return integers[index] + CalculateSum(integers, --index);
        }
    }
}

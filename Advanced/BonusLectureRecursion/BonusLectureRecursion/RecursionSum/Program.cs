namespace RecursionSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine($"Sum: {Sum(numbers,0)}");
        }

        private static int Sum(int[] numbers, int index)
        {
            if (index == numbers.Length)
            {
                return 0;
            }

            int sum = numbers[index] + Sum(numbers, ++index);
            return sum;
        }
    }
}

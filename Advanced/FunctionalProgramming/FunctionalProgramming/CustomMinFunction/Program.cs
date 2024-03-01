namespace CustomMinFunction
{
    internal class Program
    {
        static void Main()
        {
            //Create a simple program that reads from the console a set of integers and prints back on the console the smallest number from the collection. Use Func<T, T>.

            HashSet<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();
            Func<int, int, int> minNumber = (a, b) => a < b ? a : b;
            Console.WriteLine(numbers.Aggregate(minNumber));

            //or can write the func to aggregate

            //Func<HashSet<int>, int> minNumber = numbers =>
            //{
            //    int min = int.MaxValue;

            //    foreach (int number in numbers)
            //    {
            //        if (number < min)
            //        {
            //            min = number;
            //        }
            //    }

            //    return min;
            //};
            // Console.WriteLine(min(numbers));

        }
        }
    }

namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main()
        {
            //Create a program that reverses a collection and removes elements that are divisible by a given integer n. Use predicates/functions.
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int divisor = int.Parse(Console.ReadLine());

            Func<List<int>, int, List<int>> filterNumbers = (numberList, divisorNumber) =>
            {
                List<int> filteredNumbers = new List<int>();

                foreach (int number in numberList)
                {
                    if (number % divisorNumber != 0)
                    {
                        filteredNumbers.Add(number);
                    }
                }

                return filteredNumbers;
            };

            Func<List<int>, List<int>> reverseList = numberList =>
            {
                List<int> reversedList = new();

                foreach (int number in numberList)
                {
                    reversedList.Insert(0,number);
                }

                return reversedList;
            };

            numbers = reverseList(numbers);
            Console.WriteLine(string.Join(' ', filterNumbers(numbers, divisor)));
        }
    }
}
